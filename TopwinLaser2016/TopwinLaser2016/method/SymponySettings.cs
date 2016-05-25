using Topwin.SymphonyAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TopwinLaser2016
{
    public class SymponySettings
    {
        // Axis
        public Dictionary<AxisID, AxisParameters> AxisParameterList { get; set; }

        // Galvo :--
        public int GalvoFocalLength { get; set; }
        public int GalvoMotionDelay { get; set; }
        public bool GalvoXFlipped { get; set; }
        public bool GalvoYFlipped { get; set; }

        //IO :---
        public Dictionary<int, bool> DigitalOutputs { get; set; }

        //Laser :--
        public bool LaserEnabled { get; set; }
        public bool LaserGatePolarity { get; set; }
        public bool LaserClockPolarity { get; set; }
        public bool LaserSimmerGate { get; set; }
        public bool LaserSimmerClock { get; set; }
        public int LaserSimmerDelay { get; set; }
        public int LaserSimmerPW { get; set; }
        public int LaserSimmerFreq { get; set; }
        public int LaserRepRate { get; set; }
        public int LaserGateStartDelay { get; set; }
        public int LaserGateStopDelay { get; set; }
        public int LaserFirstPulseDelay { get; set; }

        // stage

        public Dictionary<StageID, StageParameters> StageParametersList { get; set; }

        public void ReadFromSymphony(Symphony s)
        {
            AxisParameterList = new Dictionary<AxisID, AxisParameters>();
            string[] axisList = Enum.GetNames(typeof(AxisID));
            foreach (string axisStr in axisList)
            {
                AxisID axis = (AxisID)Enum.Parse(typeof(AxisID), axisStr);
                AxisParameters param = new AxisParameters();
                param.ReadFromAxis(axis, s);
                AxisParameterList.Add(axis, param);
            }

            StageParametersList = new Dictionary<StageID, StageParameters>();
            string[] stageList = Enum.GetNames(typeof(StageID));
            foreach (string stageStr in stageList)
            {
                StageID stage = (StageID)Enum.Parse(typeof(StageID), stageStr);
                StageParameters param = new StageParameters();
                param.ReadFromStage(stage, s);
                StageParametersList.Add(stage, param);
            }

            GalvoFocalLength = s.GetGalvoFocalLength();
            GalvoMotionDelay = s.GetGalvoMotionDelay();
            bool xFlipped, yFlipped;

            s.GetGalvoFlipped(out xFlipped, out yFlipped);
            GalvoXFlipped = xFlipped;
            GalvoYFlipped = yFlipped;

            DigitalOutputs = new Dictionary<int, bool>();
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    bool val = s.GetDigitalOutput(i);
                    DigitalOutputs.Add(i, val);
                }
                catch
                {
                    break;
                }
            }

            LaserEnabled = s.GetLaserEnabled();
            LaserGatePolarity = s.GetGatePolarity();
            LaserClockPolarity = s.GetClockPolarity();
            bool gate, clock;
            int delay, freq, pw;
            s.GetLaserSimmer(out gate, out clock, out delay, out freq, out pw);
            LaserSimmerGate = gate;
            LaserSimmerClock = clock;
            LaserSimmerDelay = delay;
            LaserSimmerFreq = freq;
            LaserSimmerPW = pw;

            LaserRepRate = s.GetRepRate();
            LaserGateStartDelay = s.GetGateStartDelay();
            LaserGateStopDelay = s.GetGateStopDelay();
            LaserFirstPulseDelay = s.GetFirstPulseDelay();
        }

        public string SetToSymphony(Symphony s)
        {
            StringBuilder errorSB = new StringBuilder();

            foreach (AxisID axis in AxisParameterList.Keys)
            {
                AxisParameters param = AxisParameterList[axis];
                param.SetToAxis(axis, s, errorSB);
            }

            foreach (StageID stage in StageParametersList.Keys)
            {
                StageParameters param = StageParametersList[stage];
                param.SetToStage(stage, s, errorSB);
            }

            try
            {
                s.SetGalvoFocalLength(GalvoFocalLength);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetGalvoFocalLength(" + GalvoFocalLength.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetGalvoMotionDelay(GalvoMotionDelay);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetGalvoFocalLength(" + GalvoMotionDelay.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetGalvoFlipped(GalvoXFlipped, GalvoYFlipped);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetGalvoFlipped(" + GalvoXFlipped.ToString() + ", " + GalvoYFlipped.ToString() + "):" + ex.Message);
            }

            foreach (int i in DigitalOutputs.Keys)
            {
                try
                {
                    s.SetDigitalOutput(i, DigitalOutputs[i]);
                }
                catch (Exception ex)
                {
                    errorSB.AppendLine("SetDigitalOutput(" + i.ToString() + " , " + DigitalOutputs[i].ToString() + ")" + ex.Message);
                }
            }

            try
            {
                s.SetLaserEnabled(LaserEnabled);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetLaserEnabled(" + LaserEnabled.ToString() + "):" + ex.Message);
            }

            //s.SetLaserOn(LaseOn);

            try
            {
                s.SetGatePolarity(LaserGatePolarity);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetGatePolarity(" + LaserGatePolarity.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetClockPolarity(LaserClockPolarity);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetClockPolarity(" + LaserClockPolarity.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetLaserSimmer(LaserSimmerGate, LaserSimmerClock, LaserSimmerDelay, LaserSimmerFreq, LaserSimmerPW);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetLaserSimmer(" + LaserSimmerGate.ToString() + " , " + LaserSimmerClock.ToString() + " , " + LaserSimmerDelay.ToString() + " , " + LaserSimmerFreq.ToString() + " , " + LaserSimmerPW.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetRepRate(LaserRepRate);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetRepRate(" + LaserRepRate.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetGateStartDelay(LaserGateStartDelay);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetGateStartDelay(" + LaserGateStartDelay.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetGateStopDelay(LaserGateStopDelay);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetGateStopDelay(" + LaserGateStopDelay.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetFirstPulseDelay(LaserFirstPulseDelay);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetFirstPulseDelay(" + LaserFirstPulseDelay.ToString() + "):" + ex.Message);
            }

            return errorSB.ToString();
        }

        internal void SavetoXml(string path)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement rootElement = doc.CreateElement("SymponySettings");

            XmlElement axisParametersElement = doc.CreateElement("AxisParameters");
            foreach (AxisID axis in AxisParameterList.Keys)
            {
                axisParametersElement.AppendChild(AxisParameterList[axis].GetXml(doc, axis));
            }
            rootElement.AppendChild(axisParametersElement);

            XmlElement stageParametersElement = doc.CreateElement("StageParameters");
            foreach (StageID stage in StageParametersList.Keys)
            {
                stageParametersElement.AppendChild(StageParametersList[stage].GetXml(doc, stage));
            }
            rootElement.AppendChild(stageParametersElement);

            XmlElement currentElement = doc.CreateElement("GalvoFocalLength");
            currentElement.InnerText = GalvoFocalLength.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("GalvoFocalLength");
            currentElement.InnerText = GalvoFocalLength.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("GalvoMotionDelay");
            currentElement.InnerText = GalvoMotionDelay.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("GalvoXFlipped");
            currentElement.InnerText = GalvoXFlipped.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("GalvoYFlipped");
            currentElement.InnerText = GalvoYFlipped.ToString();
            rootElement.AppendChild(currentElement);

            XmlElement digitalOutputsElement = doc.CreateElement("DigitalOutputs");
            foreach (int item in DigitalOutputs.Keys)
            {
                XmlElement outputElement = doc.CreateElement("OutputParam");

                currentElement = doc.CreateElement("Output");
                currentElement.InnerText = item.ToString();
                outputElement.AppendChild(currentElement);

                currentElement = doc.CreateElement("Value");
                currentElement.InnerText = DigitalOutputs[item].ToString();
                outputElement.AppendChild(currentElement);

                digitalOutputsElement.AppendChild(outputElement);
            }
            rootElement.AppendChild(digitalOutputsElement);


            currentElement = doc.CreateElement("LaserEnabled");
            currentElement.InnerText = LaserEnabled.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserGatePolarity");
            currentElement.InnerText = LaserGatePolarity.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserClockPolarity");
            currentElement.InnerText = LaserClockPolarity.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserSimmerGate");
            currentElement.InnerText = LaserSimmerGate.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserSimmerClock");
            currentElement.InnerText = LaserSimmerClock.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserSimmerDelay");
            currentElement.InnerText = LaserSimmerDelay.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserSimmerPW");
            currentElement.InnerText = LaserSimmerPW.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserSimmerFreq");
            currentElement.InnerText = LaserSimmerFreq.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserRepRate");
            currentElement.InnerText = LaserRepRate.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserGateStartDelay");
            currentElement.InnerText = LaserGateStartDelay.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserGateStopDelay");
            currentElement.InnerText = LaserGateStopDelay.ToString();
            rootElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("LaserFirstPulseDelay");
            currentElement.InnerText = LaserFirstPulseDelay.ToString();
            rootElement.AppendChild(currentElement);

            doc.AppendChild(rootElement);
            doc.Save(path);
        }

        internal void ReadFromXml(string path)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode SymponySettingsNode = doc.SelectSingleNode("SymponySettings");

            XmlNodeList axisParameterNodes = SymponySettingsNode.SelectNodes("AxisParameters/AxisParameter");

            AxisParameterList = new Dictionary<AxisID, AxisParameters>();
            foreach (XmlNode paramNode in axisParameterNodes)
            {
                AxisParameters param = new AxisParameters();
                AxisID axis = param.ReadFromXml(paramNode);
                AxisParameterList.Add(axis, param);
            }

            XmlNodeList stageParameterNodes = SymponySettingsNode.SelectNodes("StageParameters/StageParameter");

            StageParametersList = new Dictionary<StageID, StageParameters>();
            foreach (XmlNode paramNode in stageParameterNodes)
            {
                StageParameters param = new StageParameters();
                StageID stage = param.ReadFromXml(paramNode);
                StageParametersList.Add(stage, param);
            }

            GalvoFocalLength = int.Parse(SymponySettingsNode.SelectSingleNode("GalvoFocalLength").InnerText);
            GalvoMotionDelay = int.Parse(SymponySettingsNode.SelectSingleNode("GalvoMotionDelay").InnerText);
            GalvoXFlipped = bool.Parse(SymponySettingsNode.SelectSingleNode("GalvoXFlipped").InnerText);
            GalvoYFlipped = bool.Parse(SymponySettingsNode.SelectSingleNode("GalvoYFlipped").InnerText);

            XmlNodeList digitalOutputParamNodeList = SymponySettingsNode.SelectNodes("DigitalOutputs/OutputParam");

            DigitalOutputs = new Dictionary<int, bool>();
            foreach (XmlNode paramNode in digitalOutputParamNodeList)
            {
                int output = int.Parse(paramNode.SelectSingleNode("Output").InnerText);
                bool value = bool.Parse(paramNode.SelectSingleNode("Value").InnerText);
                DigitalOutputs.Add(output, value);
            }

            LaserEnabled = bool.Parse(SymponySettingsNode.SelectSingleNode("LaserEnabled").InnerText);
            LaserGatePolarity = bool.Parse(SymponySettingsNode.SelectSingleNode("LaserGatePolarity").InnerText);
            LaserClockPolarity = bool.Parse(SymponySettingsNode.SelectSingleNode("LaserClockPolarity").InnerText);
            LaserSimmerGate = bool.Parse(SymponySettingsNode.SelectSingleNode("LaserSimmerGate").InnerText);
            LaserSimmerClock = bool.Parse(SymponySettingsNode.SelectSingleNode("LaserSimmerClock").InnerText);
            LaserSimmerDelay = int.Parse(SymponySettingsNode.SelectSingleNode("LaserSimmerDelay").InnerText);
            LaserSimmerPW = int.Parse(SymponySettingsNode.SelectSingleNode("LaserSimmerPW").InnerText);
            LaserSimmerFreq = int.Parse(SymponySettingsNode.SelectSingleNode("LaserSimmerFreq").InnerText);
            LaserRepRate = int.Parse(SymponySettingsNode.SelectSingleNode("LaserRepRate").InnerText);
            LaserGateStartDelay = int.Parse(SymponySettingsNode.SelectSingleNode("LaserGateStartDelay").InnerText);
            LaserGateStopDelay = int.Parse(SymponySettingsNode.SelectSingleNode("LaserGateStopDelay").InnerText);
            LaserFirstPulseDelay = int.Parse(SymponySettingsNode.SelectSingleNode("LaserFirstPulseDelay").InnerText);

        }
    }

    public class StageParameters
    {
        public bool Enabled { get; set; }
        public bool StepPolarity { get; set; }
        public bool LimitPolarity { get; set; }
        public bool DirPolarity { get; set; }
        public double PulseShapeStartupTime { get; set; }
        public double PulseDhapeHoldTime { get; set; }
        public int Delay { get; set; }

        public void ReadFromStage(StageID stage, Symphony s)
        {
            Enabled = s.GetStageEnabled(stage);
            StepPolarity = s.GetStageStepPolarity(stage);
            LimitPolarity = s.GetStageLimitPolarity(stage);
            
            DirPolarity = s.GetStageDirPolarity(stage);

            double startupTime,holdTime;
            s.GetStagePulseShape(stage, out startupTime, out holdTime);
            PulseShapeStartupTime = startupTime;
            PulseDhapeHoldTime = holdTime;

            Delay = s.GetStageDelay(stage);
        }

        public void SetToStage(StageID stage, Symphony s, StringBuilder essorSB)
        {
            try
            {
                s.SetStageEnabled(stage, Enabled);
            }
            catch (Exception ex)
            {
                essorSB.AppendLine("SetStageEnabled("+stage.ToString()+" , "+Enabled.ToString()+"):" + ex.Message);
            }

            try
            {
                s.SetStageStepPolarity(stage, StepPolarity);
            }
            catch (Exception ex)
            {
                essorSB.AppendLine("SetStageStepPolarity(" + stage.ToString() + " , " + StepPolarity.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetStageLimitPolarity(stage, LimitPolarity);

            }
            catch (Exception ex)
            {
                essorSB.AppendLine("SetStageLimitPolarity(" + stage.ToString() + " , " + LimitPolarity.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetStageDirPolarity(stage, DirPolarity);
            }
            catch (Exception ex)
            {
                essorSB.AppendLine("SetStageDirPolarity(" + stage.ToString() + " , " + DirPolarity.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetStagePulseShape(stage, PulseShapeStartupTime, PulseDhapeHoldTime);
            }
            catch (Exception ex)
            {
                essorSB.AppendLine("SetStagePulseShape(" + stage.ToString() + " , " + PulseShapeStartupTime.ToString() + " , " + PulseDhapeHoldTime.ToString() + "):" + ex.Message);
            }

            try
            {
                s.SetStageDelay(stage, Delay);
            }
            catch (Exception ex)
            {
                essorSB.AppendLine("SetStageDelay(" + stage.ToString() + " , " + Delay.ToString() + "):" + ex.Message);
            }
        }

        internal XmlNode GetXml(XmlDocument doc, StageID stage)
        {
           XmlElement stageParameterElement=doc.CreateElement("StageParameter");

           XmlElement currentElement = doc.CreateElement("StageID");
           currentElement.InnerText = stage.ToString();
           stageParameterElement.AppendChild(currentElement);

           currentElement = doc.CreateElement("Enabled");
           currentElement.InnerText = Enabled.ToString();
           stageParameterElement.AppendChild(currentElement);

           currentElement = doc.CreateElement("StepPolarity");
           currentElement.InnerText = StepPolarity.ToString();
           stageParameterElement.AppendChild(currentElement);

           currentElement = doc.CreateElement("LimitPolarity");
           currentElement.InnerText = LimitPolarity.ToString();
           stageParameterElement.AppendChild(currentElement);

           currentElement = doc.CreateElement("DirPolarity");
           currentElement.InnerText = DirPolarity.ToString();
           stageParameterElement.AppendChild(currentElement);

           currentElement = doc.CreateElement("PulseShapeStartupTime");
           currentElement.InnerText = PulseShapeStartupTime.ToString();
           stageParameterElement.AppendChild(currentElement);

           currentElement = doc.CreateElement("PulseDhapeHoldTime");
           currentElement.InnerText = PulseDhapeHoldTime.ToString();
           stageParameterElement.AppendChild(currentElement);

           currentElement = doc.CreateElement("Delay");
           currentElement.InnerText = Delay.ToString();
           stageParameterElement.AppendChild(currentElement);

           return stageParameterElement;
        }

        internal StageID ReadFromXml(XmlNode paramNode)
        {
            StageID stageID = (StageID)Enum.Parse(typeof(StageID), paramNode.SelectSingleNode("StageID").InnerText);
            Enabled = bool.Parse(paramNode.SelectSingleNode("Enabled").InnerText);
            StepPolarity = bool.Parse(paramNode.SelectSingleNode("StepPolarity").InnerText);
            LimitPolarity = bool.Parse(paramNode.SelectSingleNode("LimitPolarity").InnerText);
            DirPolarity = bool.Parse(paramNode.SelectSingleNode("DirPolarity").InnerText);
            PulseShapeStartupTime = double.Parse(paramNode.SelectSingleNode("PulseShapeStartupTime").InnerText);
            PulseDhapeHoldTime = double.Parse(paramNode.SelectSingleNode("PulseDhapeHoldTime").InnerText);
            Delay = int.Parse(paramNode.SelectSingleNode("Delay").InnerText);

            return stageID;
        }
    }

    public class AxisParameters
    {
        public double MinMT { get; set; }
        public double MaxVel { get; set; }
        public double MaxAccel { get; set; }
        public bool UseUnityTransform { get; set; }

        public void ReadFromAxis(AxisID axis, Symphony s)
        {
            double minMt, maxVel,maxAccel;

            s.GetKinematicConstraints(axis, out minMt, out maxVel, out maxAccel);
            MinMT = minMt;
            MaxVel = maxVel;
            MaxAccel = maxAccel;

            if (axis != AxisID.Z_STAGE)
            {
                UseUnityTransform = s.GetUseUnityTransform(axis);
            }
        }

        public void SetToAxis(AxisID axis, Symphony s, StringBuilder errorSB)
        {
            try
            {
                s.SetKinematicConstraints(axis, MinMT, MaxVel, MaxAccel);
            }
            catch (Exception ex)
            {
                errorSB.AppendLine("SetKinematicConstraints(" + axis.ToString() + " , " + MinMT.ToString() + " , " + MaxVel.ToString() + " , " + MaxAccel.ToString() + ")" + ex.Message);
            }

            if (axis != AxisID.Z_STAGE)
            {
                try
                {
                    s.SetUseUnityTransform(axis, UseUnityTransform);
                }
                catch (Exception ex)
                {
                    errorSB.AppendLine("SetUseUnityTransform(" + axis.ToString() + " , " + UseUnityTransform.ToString() + ")" + ex.Message);
                }
            }
        }

        internal XmlNode GetXml(XmlDocument doc, AxisID axis)
        {
            XmlElement axisParameterElement = doc.CreateElement("AxisParameter");

            XmlElement currentElement = doc.CreateElement("AxisID");
            currentElement.InnerText = axis.ToString();
            axisParameterElement.AppendChild(currentElement);
                
            currentElement = doc.CreateElement("MinMT");
            currentElement.InnerText = MinMT.ToString();
            axisParameterElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("MaxVel");
            currentElement.InnerText = MaxVel.ToString();
            axisParameterElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("MaxAccel");
            currentElement.InnerText = MaxAccel.ToString();
            axisParameterElement.AppendChild(currentElement);

            currentElement = doc.CreateElement("UseUnityTransform");
            currentElement.InnerText = UseUnityTransform.ToString();
            axisParameterElement.AppendChild(currentElement);

            return axisParameterElement;
        }

        internal AxisID ReadFromXml(XmlNode paramNode)
        {
            AxisID axis = (AxisID)Enum.Parse(typeof(AxisID), paramNode.SelectSingleNode("AxisID").InnerText);
            MinMT = double.Parse(paramNode.SelectSingleNode("MinMT").InnerText);
            MaxVel = double.Parse(paramNode.SelectSingleNode("MaxVel").InnerText);
            MaxAccel = double.Parse(paramNode.SelectSingleNode("MaxAccel").InnerText);
            UseUnityTransform = bool.Parse(paramNode.SelectSingleNode("UseUnityTransform").InnerText);

            return axis;
        }
    }
}
