using AR.Drone.Avionics;
using AR.Drone.Avionics.Objectives;
using AR.Drone.Avionics.Objectives.IntentObtainers;
using AR.Drone.Client;
using AR.Drone.Client.Command;
using AR.Drone.Client.Configuration;
using AR.Drone.Data;
using AR.Drone.Data.Navigation;
using AR.Drone.Data.Navigation.Native;
using AR.Drone.Media;
using AR.Drone.Video;

using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AR.Drone.WinApp
{
    public partial class MainForm : Form
    {
        private const string ARDroneTrackFileExt = ".ardrone";
        private const string ARDroneTrackFilesFilter = "AR.Drone track files (*.ardrone)|*.ardrone";
        private static DroneClient droneClient;
        private readonly VideoPacketDecoderWorker videoPacketDecoderWorker;
        private VideoFrame frame;
        private Bitmap frameBitmap;
        private uint frameNumber;
        private NavigationData navigationData;
        private NavigationPacket navigationPacket;
        private PacketRecorder packetRecorderWorker;
        private FileStream recorderStream;
        private Autopilot autopilot;
        private string hostname = "192.168.1.1";

        /// <summary>
        /// Obrót o 300°
        /// </summary>
        const float ROTATION_OF_THREE_HUNDRED_DEGREES = 5.24f;

        /// <summary>
        /// Obrót o 90°
        /// </summary>
        const float TURN_OF_NINETY_DEGREES = 1.57f;

        /// <summary>
        /// Pochylenie o 10°
        /// </summary>
        const float SLOPE_OF_TEN_DEGREES = 0.18f;

        /// <summary>
        /// Średni dystans pokonany w ciągu pięciu sekund
        /// </summary>
        const int AVG_DISTANCE = 12;

        /// <summary>
        /// Średni czas przelotu 12 metrów w milisekundach
        /// </summary>
        const int AVG_TIME = 5000;

        /// <summary>
        /// Czas na rozpęd i wychamowanie drona w milisekundach 
        /// </summary>
        const int ACCELERATE_TIME = 1000;

        /// <summary>
        /// Typy lotów
        /// </summary>
        public enum FlightType
        {
            /// <summary>
            /// Lot do przodu
            /// </summary>
            Forward,

            /// <summary>
            /// Lot do tyłu
            /// </summary>
            Back,

            /// <summary>
            /// Obrót w lewo
            /// </summary>
            Turn_Left,

            /// <summary>
            /// Obrót w prawo
            /// </summary>
            Turn_Right,

            /// <summary>
            /// Lot w lewo (z przechyleniem)
            /// </summary>
            Lean_Left,

            /// <summary>
            /// Lot w prawo (z przechyleniem)
            /// </summary>
            Lean_Right,

            /// <summary>
            /// Lot w formie trójkąta
            /// </summary>
            Triangle,

            /// <summary>
            /// Lot w formie kwadratu
            /// </summary>
            Square
        }

        /// <summary>
        /// Metoda odpowiedzialna za inicjalizacje danych rozwijanej listy typów lotu
        /// </summary>
        private void InitComboBoxFlightType()
        {
            var container = Enum.GetValues(typeof(FlightType));

            var dataSource = new string[container.Length];

            int index = 0;

            foreach (var element in container)
            {
                string value = element.ToString();

                if (value.Contains("_"))
                    value = value.Replace('_', ' ');

                dataSource[index] = value;
                index++;
            }

            comboBoxFlightType.DataSource = dataSource;
        }

        public MainForm()
        {
            InitializeComponent();
            InitComboBoxFlightType();

            videoPacketDecoderWorker = new VideoPacketDecoderWorker(PixelFormat.BGR24, true, OnVideoPacketDecoded);

            timerStateUpdate.Enabled = true;
            timerVideoUpdate.Enabled = true;

            videoPacketDecoderWorker.UnhandledException += UnhandledException;
        }

        private void UnhandledException(object sender, Exception exception)
        {
            MessageBox.Show(exception.ToString(), "Unhandled Exception (Ctrl+C)", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text += Environment.Is64BitProcess ? " [64-bit]" : " [32-bit]";
        }

        protected override void OnClosed(EventArgs e)
        {
            if (autopilot != null)
            {
                autopilot.UnbindFromClient();
                autopilot.Stop();
                autopilot.Dispose();
            }

            if (droneClient != null)
            {
                droneClient.Stop();
                droneClient.Dispose();
            }

            if (videoPacketDecoderWorker != null)
            {
                videoPacketDecoderWorker.Stop();
                videoPacketDecoderWorker.Dispose();
            }

            base.OnClosed(e);
        }

        private void OnNavigationPacketAcquired(NavigationPacket packet)
        {
            if (packetRecorderWorker != null && packetRecorderWorker.IsAlive)
                packetRecorderWorker.EnqueuePacket(packet);

            navigationPacket = packet;
        }

        private void OnVideoPacketAcquired(VideoPacket packet)
        {
            if (packetRecorderWorker != null && packetRecorderWorker.IsAlive)
                packetRecorderWorker.EnqueuePacket(packet);
            if (videoPacketDecoderWorker.IsAlive)
                videoPacketDecoderWorker.EnqueuePacket(packet);
        }

        private void OnVideoPacketDecoded(VideoFrame videoFrame)
        {
            frame = videoFrame;
        }

        private void OnButtonActivateClicked(object sender, EventArgs e)
        {
            if (IsIpAddress(textBoxHost.Text))
                hostname = textBoxHost.Text;

            droneClient = new DroneClient(hostname);

            droneClient.NavigationPacketAcquired += OnNavigationPacketAcquired;
            droneClient.VideoPacketAcquired += OnVideoPacketAcquired;
            droneClient.NavigationDataAcquired += data => navigationData = data;

            droneClient.Start();
            videoPacketDecoderWorker.Start();

            buttonActivate.Enabled = false;
            textBoxHost.Enabled = false;
            buttonDeactivate.Enabled = true;
            groupBoxControlPanel.Enabled = true;
            pictureBoxVideo.Enabled = true;
            buttonSwitchCamera.Enabled = true;
        }

        private bool IsIpAddress(string ipAddress)
        {
            string pattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

            return Regex.IsMatch(ipAddress, pattern);
        }

        private void OnButtonDeactivateClicked(object sender, EventArgs e)
        {
            videoPacketDecoderWorker.Dispose();
            droneClient.Dispose();

            buttonActivate.Enabled = true;
            textBoxHost.Enabled = true;
            buttonDeactivate.Enabled = false;
            groupBoxControlPanel.Enabled = false;
            pictureBoxVideo.Enabled = false;
            buttonSwitchCamera.Enabled = false;
        }

        private void OnTimerVideoUpdateTick(object sender, EventArgs e)
        {
            if (frame == null || frameNumber == frame.Number)
                return;
            frameNumber = frame.Number;

            if (frameBitmap == null)
                frameBitmap = VideoHelper.CreateBitmap(ref frame);
            else
                VideoHelper.UpdateBitmap(ref frameBitmap, ref frame);

            pictureBoxVideo.Image = frameBitmap;
        }

        private void OnTimerStateUpdateTick(object sender, EventArgs e)
        {
            NavdataBag navdataBag;
            if (navigationPacket.Data != null && NavdataBagParser.TryParse(ref navigationPacket, out navdataBag))
            {
                var ctrl_state = (CTRL_STATES)(navdataBag.demo.ctrl_state >> 0x10);
                var flying_state = (FLYING_STATES)(navdataBag.demo.ctrl_state & 0xffff);
            }

            if (autopilot != null && !autopilot.Active && buttonExecute.ForeColor != Color.Black)
            {
                buttonExecute.ForeColor = Color.Black;
                groupBoxDigitalSection.Enabled = true;
            }
        }

        private void DumpBranch(TreeNodeCollection nodes, object o)
        {
            Type type = o.GetType();

            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                TreeNode node = nodes.GetOrCreate(fieldInfo.Name);
                object value = fieldInfo.GetValue(o);

                DumpValue(fieldInfo.FieldType, node, value);
            }

            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                TreeNode node = nodes.GetOrCreate(propertyInfo.Name);
                object value = propertyInfo.GetValue(o, null);

                DumpValue(propertyInfo.PropertyType, node, value);
            }
        }

        private void DumpValue(Type type, TreeNode node, object value)
        {
            if (value == null)
                node.Text = node.Name + ": null";
            else
            {
                if (type.Namespace.StartsWith("System") || type.IsEnum)
                    node.Text = node.Name + ": " + value;
                else
                    DumpBranch(node.Nodes, value);
            }
        }

        private void OnButtonTakeoffClick(object sender, EventArgs e)
        {
            if (checkBoxFlatTrim.Checked)
                droneClient.FlatTrim();

            droneClient.Takeoff();

            checkBoxFlatTrim.Enabled = false;
            buttonTakeoff.Enabled = false;
            buttonExecute.Enabled = true;
            buttonLand.Enabled = true;
            buttonHover.Enabled = true;
            groupBoxAutopilotSection.Enabled = true;
            groupBoxDigitalSection.Enabled = true;

        }

        private void OnButtonLandClicked(object sender, EventArgs e)
        {
            droneClient.Land();

            checkBoxFlatTrim.Enabled = true;
            buttonTakeoff.Enabled = true;
            buttonExecute.Enabled = false;
            buttonLand.Enabled = false;
            buttonHover.Enabled = false;
            groupBoxAutopilotSection.Enabled = false;
            groupBoxDigitalSection.Enabled = false;
        }

        private void OnButtonEmergencyClicked(object sender, EventArgs e)
        {
            droneClient.Emergency();

            checkBoxFlatTrim.Enabled = true;
            buttonTakeoff.Enabled = true;
            buttonExecute.Enabled = false;
            buttonLand.Enabled = false;
            buttonHover.Enabled = false;
            groupBoxAutopilotSection.Enabled = false;
            groupBoxDigitalSection.Enabled = false;
        }

        private void OnButtonResetClicked(object sender, EventArgs e)
        {
            droneClient.ResetEmergency();

            checkBoxFlatTrim.Enabled = true;
            buttonTakeoff.Enabled = true;
            buttonExecute.Enabled = false;
            buttonLand.Enabled = false;
            buttonHover.Enabled = false;
            groupBoxAutopilotSection.Enabled = false;
            groupBoxDigitalSection.Enabled = false;
        }

        private void OnButtonSwitchCamClicked(object sender, EventArgs e)
        {
            var configuration = new Settings();
            configuration.Video.Channel = VideoChannelType.Next;
            droneClient.Send(configuration);
        }

        private void OnButtonHoverClicked(object sender, EventArgs e)
        {
            droneClient.Hover();
        }

        private void OnButtonUpClicked(object sender, EventArgs e)
        {
            droneClient.Progress(FlightMode.Progressive, gaz: 0.25f);
        }

        private void OnButtonDownClicked(object sender, EventArgs e)
        {
            droneClient.Progress(FlightMode.Progressive, gaz: -0.25f);
        }

        private void OnButtonTurnLeftClicked(object sender, EventArgs e)
        {
            droneClient.Progress(FlightMode.Progressive, yaw: 0.25f);
        }

        private void OnButtonTurnRightClicked(object sender, EventArgs e)
        {
            droneClient.Progress(FlightMode.Progressive, yaw: -0.25f);
        }

        private void OnButtonLeanLeftClicked(object sender, EventArgs e)
        {
            droneClient.Progress(FlightMode.Progressive, roll: -0.05f);
        }

        private void OnButtonLeanRightClicked(object sender, EventArgs e)
        {
            droneClient.Progress(FlightMode.Progressive, roll: 0.05f);
        }

        private void OnbuttonForwardClicked(object sender, EventArgs e)
        {
            droneClient.Progress(FlightMode.Progressive, pitch: -0.05f);
        }

        private void OnButtonBackClicked(object sender, EventArgs e)
        {
            droneClient.Progress(FlightMode.Progressive, pitch: 0.05f);
        }

        // Make sure 'autopilot' variable is initialized with an object
        private void CreateAutopilot()
        {
            if (autopilot != null) return;

            autopilot = new Autopilot(droneClient);
            autopilot.OnOutOfObjectives += Autopilot_OnOutOfObjectives;
            autopilot.BindToClient();
            autopilot.Start();
        }

        // Event that occurs when no objectives are waiting in the autopilot queue
        private void Autopilot_OnOutOfObjectives()
        {
            autopilot.Active = false;
        }

        // Create a simple mission for autopilot
        private void CreateAutopilotMission(FlightType type, int time)
        {
            autopilot.ClearObjectives();

            if (droneClient.NavigationData.State.HasFlag(NavigationState.Flying))
            {
                Console.WriteLine($"Flight type: {type} in {time}ms");

                switch (type)
                {
                    case FlightType.Forward:
                        // Wykonaj lot w przód z pochyleniem 10° w ciągu zadanego czasu
                        autopilot.EnqueueObjective(Objective.Create(time, new SetPitch(-SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(2000));
                        break;

                    case FlightType.Back:
                        // Wykonaj lot do tyłu z pochyleniem 10° w ciągu zadanego czasu
                        autopilot.EnqueueObjective(Objective.Create(time, new SetPitch(SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(2000));
                        break;

                    case FlightType.Turn_Left:
                        // Wykonaj obrót 90° w lewo
                        autopilot.EnqueueObjective(Objective.Create(2000, new SetYaw(-TURN_OF_NINETY_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(2000));
                        break;

                    case FlightType.Turn_Right:
                        // Wykonaj obrót 90° w prawo
                        autopilot.EnqueueObjective(Objective.Create(2000, new SetYaw(TURN_OF_NINETY_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(2000));
                        break;

                    case FlightType.Lean_Left:
                        // Wykonaj lot w lewo z pochyleniem 10° w ciągu zadanego czasu
                        autopilot.EnqueueObjective(Objective.Create(time, new SetRoll(-SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(2000));
                        break;

                    case FlightType.Lean_Right:
                        // Wykonaj lot w prawo z pochyleniem 10° w ciągu zadanego czasu
                        autopilot.EnqueueObjective(Objective.Create(time, new SetRoll(SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(2000));
                        break;

                    case FlightType.Triangle:
                        // Do przodu z nachyleniem 10°
                        autopilot.EnqueueObjective(Objective.Create(time, new SetPitch(-SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(3000));

                        // Obrót 300° w prawo
                        autopilot.EnqueueObjective(Objective.Create(2000, new SetYaw(ROTATION_OF_THREE_HUNDRED_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(3000));

                        // Do przodu z nachyleniem 10°
                        autopilot.EnqueueObjective(Objective.Create(time, new SetPitch(-SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(3000));

                        // Obrót 300° w prawo
                        autopilot.EnqueueObjective(Objective.Create(2000, new SetYaw(ROTATION_OF_THREE_HUNDRED_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(3000));

                        // Do przodu z nachyleniem 10°
                        autopilot.EnqueueObjective(Objective.Create(time, new SetPitch(-SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(3000));

                        // Obrót 300° w prawo
                        autopilot.EnqueueObjective(Objective.Create(2000, new SetYaw(ROTATION_OF_THREE_HUNDRED_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(3000));
                        break;

                    case FlightType.Square:
                        // Do przodu z nachyleniem 10°
                        autopilot.EnqueueObjective(Objective.Create(2000, new SetPitch(-SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(3000));

                        // W lewo z nachyleniem 10°
                        autopilot.EnqueueObjective(Objective.Create(2000, new SetRoll(-SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(3000));

                        // Do tyłu z nachyleniem 10°
                        autopilot.EnqueueObjective(Objective.Create(2000, new SetPitch(SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(3000));

                        // W prawo z nachyleniem 10°
                        autopilot.EnqueueObjective(Objective.Create(2000, new SetRoll(SLOPE_OF_TEN_DEGREES)));
                        autopilot.EnqueueObjective(new Hover(3000));
                        break;
                }
            }
            else // Just take off if the drone is on the ground
            {
                autopilot.EnqueueObjective(new FlatTrim(1000));
                autopilot.EnqueueObjective(new Takeoff(3500));
            }

            // One could use hover, but the method below, allows to gain/lose/maintain desired altitude
            autopilot.EnqueueObjective(
                Objective.Create(3000,
                    new VelocityX(0.0f),
                    new VelocityY(0.0f),
                    new Altitude(1.0f)
                )
            );

            autopilot.EnqueueObjective(new Land(5000));
        }
        /// <summary>
        /// Konwertuje odległość jaką ma przebyć dron na czas lotu wedłóg formuły
        /// </summary>
        /// <param name="distance">Odległość w metrach</param>
        /// <returns>Czas lotu w mnilisekundach</returns>
        private int GetFlightTimeInMiliseconds(int distance)
        {
            return (int) ((distance * AVG_TIME) / (double) AVG_DISTANCE) + ACCELERATE_TIME;
        }

        private void OnButtonExecuteChenged(object sender, EventArgs e)
        {
            if (!droneClient.IsActive)
                return;

            CreateAutopilot();

            int distance = (int)numericUpDownDistance.Value;

            if (autopilot.Active && distance <= 0)
                autopilot.Active = false;
            else
            {
                int time = GetFlightTimeInMiliseconds(distance);

                autopilot.Active = true;
                groupBoxDigitalSection.Enabled = false;

                buttonExecute.ForeColor = Color.DarkRed;

                switch (comboBoxFlightType.Text)
                {
                    case "Forward":
                        CreateAutopilotMission(FlightType.Forward, time);
                        break;

                    case "Back":
                        CreateAutopilotMission(FlightType.Back, time);
                        break;

                    case "Turn Left":
                        CreateAutopilotMission(FlightType.Turn_Left, time);
                        break;

                    case "Turn Right":
                        CreateAutopilotMission(FlightType.Turn_Right, time);
                        break;

                    case "Lean Left":
                        CreateAutopilotMission(FlightType.Lean_Left, time);
                        break;

                    case "Lean Right":
                        CreateAutopilotMission(FlightType.Lean_Right, time);
                        break;

                    case "Triangle":
                        CreateAutopilotMission(FlightType.Triangle, time);
                        break;

                    case "Square":
                        CreateAutopilotMission(FlightType.Square, time);
                        break;

                    default:
                        Console.WriteLine($"Switch Error: default value selected");
                        break;
                }
            }
        }

        private void OnCheckBoxFlatTrimChanged(object sender, EventArgs e)
        {
            if (checkBoxFlatTrim.Checked)
                checkBoxFlatTrim.Text = "Flat Trim: On";
            else
                checkBoxFlatTrim.Text = "Flat Trim: Off";
        }

        private void OnNumericUpDownDistanceChanged(object sender, EventArgs e)
        {
            if (numericUpDownDistance.Value < 0)
            {
                MessageBox.Show($"Distance value = {numericUpDownDistance.Value}, must be > 0");
                numericUpDownDistance.Value = 1;
            }
        }
    }
}