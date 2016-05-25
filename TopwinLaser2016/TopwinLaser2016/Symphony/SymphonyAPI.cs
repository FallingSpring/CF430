/************************
 * Usage: Symphony Package
 * Author: Mingda Du
 * Date: 18th May 2016
 * Version: 0.0.1.1
 * API Versin: 1.0.3.2
 * **********************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topwin.SymphonyAPI
{
    public enum AxisID 
    {
        GALVO = ESI.SymphonyAPI.AxisID.GALVO,
        XY_STAGE = ESI.SymphonyAPI.AxisID.XY_STAGE,
        Z_STAGE = ESI.SymphonyAPI.AxisID.Z_STAGE
    }

    public enum StageID
    {
        X = ESI.SymphonyAPI.StageID.X,
        Y = ESI.SymphonyAPI.StageID.Y,
        Z = ESI.SymphonyAPI.StageID.Z
    }

    public class Symphony
    {
        #region values
        private ESI.SymphonyAPI.Symphony m_Symphony = null;

        private static Symphony instance = new Symphony();

        public bool bSimulate { get; }

        private bool bRet { get; set; }

        #endregion

        #region common
        /// <summary>
        /// 构造函数
        /// </summary>
        private Symphony()
        {
            try
            {
                //默认为运行模式
                bSimulate = false;
                m_Symphony = new ESI.SymphonyAPI.Symphony(bSimulate);
            }
            catch
            {
                //异常时启用演示模式
                bSimulate = true;
                m_Symphony = new ESI.SymphonyAPI.Symphony(bSimulate);
            }
            bRet = true;
        }
        
        /// <summary>
        /// 单例模式避免可能存在的多次创建实例
        /// </summary>
        /// <returns></returns>
        public static Symphony GetInstance()
        {
            return instance;
        }
        #endregion

        #region Axis Commands
        /// <summary>
        /// 获取运动约束参数
        /// </summary>
        /// <param name="axis">轴编号</param>
        /// <param name="minMT">最小时间片段</param>
        /// <param name="maxVel">最大速度</param>
        /// <param name="maxAccel">最大加速度</param>
        /// <returns>函数运行结果</returns>
        public bool GetKinematicConstraints(AxisID axis, out double minMT, out double maxVel, out double maxAccel)
        {
            bRet = false;
            minMT = 0.0;
            maxVel = 0.0;
            maxAccel = 0.0;
            do
            {
                if (m_Symphony == null)
                    break;
                
                m_Symphony.GetKinematicConstraints((ESI.SymphonyAPI.AxisID)axis, out minMT, out maxVel, out maxAccel);
                bRet = true;
            } while (false);

            return bRet;
        }

        /// <summary>
        /// 设置运动约束参数
        /// </summary>
        /// <param name="axis">轴编号</param>
        /// <param name="minMT">最小时间片段</param>
        /// <param name="maxVel">最大速度</param>
        /// <param name="maxAccel">最大加速度</param>
        /// <returns>函数运行结果</returns>
        public bool SetKinematicConstraints(AxisID axis, double minMT, double maxVel, double maxAccel)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetKinematicConstraints((ESI.SymphonyAPI.AxisID)axis, minMT, maxVel, maxAccel);
                bRet = true;
            } while (false);

            return bRet;
        }

        /// <summary>
        /// 获取回零运动约束参数
        /// </summary>
        /// <param name="axis">轴编号</param>
        /// <param name="fastVel">高速度</param>
        /// <param name="slowVel">低速度</param>
        /// <returns></returns>
        public bool GetLimitSearchKinematics(AxisID axis, out double fastVel, out double slowVel)
        {
            bRet = false;
            fastVel = 0;
            slowVel = 0;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.GetLimitSearchKinematics((ESI.SymphonyAPI.AxisID)axis, out fastVel, out slowVel);
                bRet = true;
            } while (false);

            return bRet;
        }

        /// <summary>
        /// 设置回零运动约束参数
        /// </summary>
        /// <param name="axis">轴编号</param>
        /// <param name="fastVel">高速度</param>
        /// <param name="slowVel">低速度</param>
        /// <returns></returns>
        public bool SetLimitSearchKinematics(AxisID axis, double fastVel, double slowVel)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetLimitSearchKinematics((ESI.SymphonyAPI.AxisID)axis, fastVel, slowVel);
                bRet = true;
            } while (false);

            return bRet;
        }

        /// <summary>
        /// 设置校正表
        /// </summary>
        /// <param name="axis">轴编号</param>
        /// <param name="nominalVals">nominal pos</param>
        /// <param name="rawVals">raw pos</param>
        /// <returns>函数运行结果</returns>
        public bool SetTableData(AxisID axis, IList<KeyValuePair<double, double>> nominalVals, IList<KeyValuePair<double, double>> rawVals)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetTableData((ESI.SymphonyAPI.AxisID)axis, nominalVals, rawVals);
                bRet = true;                          
            } while (false);

            return bRet;
        }

        /// <summary>
        /// 虚实坐标模式切换
        /// </summary>
        /// <param name="axis">轴编号</param>
        /// <param name="unity">虚实坐标状态</param>
        /// <returns></returns>
        public bool SetUseUnityTransform(AxisID axis, bool unity)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetUseUnityTransform((ESI.SymphonyAPI.AxisID)axis, unity);
                bRet = true;
            } while (false);

            return bRet;
        }

        /// <summary>
        /// 获取虚实坐标状态
        /// </summary>
        /// <param name="axis">轴编号</param>
        /// <param name="unity">虚实坐标状态</param>
        /// <returns></returns>
        public bool GetUseUnityTransform(AxisID axis, out bool unity)
        {
            bRet = false;
            unity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                unity = m_Symphony.GetUseUnityTransform((ESI.SymphonyAPI.AxisID)axis);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetUseUnityTransform(AxisID axis)
        {
            bRet = false;
            bool unity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                unity = m_Symphony.GetUseUnityTransform((ESI.SymphonyAPI.AxisID)axis);
                bRet = true;
            } while (false);

            return unity;
        }
        #endregion

        #region Stage Commands
        public bool StageMove(StageID stage, double position, double maxVel)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.StageMove((ESI.SymphonyAPI.StageID)stage, position, maxVel);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool StageMove(double x, double y)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.StageMove(x, y);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool StageMove(double x, double y, double z)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.StageMove(x, y, z);
                bRet = false;
            } while (false);

            return bRet;
        }

        public bool GetStagePosition(StageID stage, out double position)
        {
            bRet = false;
            position = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                position = m_Symphony.GetStagePosition((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);

            return bRet;
        }

        public double GetStagePosition(StageID stage)
        {
            bRet = false;
            double position = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                position = m_Symphony.GetStagePosition((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);

            return position;
        }

        public bool SetStageRawPosition(StageID stage, double position)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetStageRawPosition((ESI.SymphonyAPI.StageID)stage, position);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool SetStageEnabled(StageID stage, bool bEnable)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetStageEnabled((ESI.SymphonyAPI.StageID)stage, bEnable);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStageEnabled(StageID stage, out bool bEnable)
        {
            bRet = false;
            bEnable = false;
            do
            {
                if (m_Symphony == null)
                    break;

                bEnable = m_Symphony.GetStageEnabled((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStageEnabled(StageID stage)
        {
            bRet = false;
            bool bEnable = false;
            do
            {
                if (m_Symphony == null)
                    break;

                bEnable = m_Symphony.GetStageEnabled((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return bEnable;
        }

        public bool FindLimits(StageID stage, int BackOff)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.FindLimits((ESI.SymphonyAPI.StageID)stage, BackOff);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool SetStageDelay(StageID stage, int Delay)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetStageDelay((ESI.SymphonyAPI.StageID)stage, Delay);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStageDelay(StageID stage, out int Delay)
        {
            bRet = false;
            Delay = 5;
            do
            {
                if (m_Symphony == null)
                    break;

                Delay = m_Symphony.GetStageDelay((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return bRet;
        }

        public int GetStageDelay(StageID stage)
        {
            bRet = false;
            int Delay = 5;
            do
            {
                if (m_Symphony == null)
                    break;

                Delay = m_Symphony.GetStageDelay((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return Delay;
        }

        public bool SetStagePulseShape(StageID stage, double SetupTime, double HoldTime)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetStagePulseShape((ESI.SymphonyAPI.StageID)stage, SetupTime, HoldTime);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStagePulseShape(StageID stage, out double SetupTime, out double HoldTime)
        {
            bRet = false;
            SetupTime = 0;
            HoldTime = 0;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.GetStagePulseShape((ESI.SymphonyAPI.StageID)stage, out SetupTime, out HoldTime);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool SetStageStepPolarity(StageID stage, bool polarity)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetStageStepPolarity((ESI.SymphonyAPI.StageID)stage, polarity);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStageStepPolarity(StageID stage, out bool polarity)
        {
            bRet = false;
            polarity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                polarity = m_Symphony.GetStageStepPolarity((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStageStepPolarity(StageID stage)
        {
            bRet = false;
            bool polarity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                polarity = m_Symphony.GetStageStepPolarity((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return polarity;
        }

        public bool SetStageDirPolarity(StageID stage, bool polarity)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetStageDirPolarity((ESI.SymphonyAPI.StageID)stage, polarity);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStageDirPolarity(StageID stage, out bool polarity)
        {
            bRet = false;
            polarity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                polarity = m_Symphony.GetStageDirPolarity((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStageDirPolarity(StageID stage)
        {
            bRet = false;
            bool polarity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                polarity = m_Symphony.GetStageDirPolarity((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return polarity;
        }

        public bool SetStageLimitPolarity(StageID stage, bool polarity)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetStageLimitPolarity((ESI.SymphonyAPI.StageID)stage, polarity);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStageLimitPolarity(StageID stage, out bool polarity)
        {
            bRet = false;
            polarity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                polarity = m_Symphony.GetStageLimitPolarity((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStageLimitPolarity(StageID stage)
        {
            bRet = false;
            bool polarity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                polarity = m_Symphony.GetStageLimitPolarity((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return polarity;
        }

        public bool SetStageLimits(StageID stage, double lowerLimit, double upperLimit)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetStageLimits((ESI.SymphonyAPI.StageID)stage, lowerLimit, upperLimit);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetStageLimits(StageID stage, out double lowerLimit, out double upperLimit)
        {
            bRet = false;
            lowerLimit = 0;
            upperLimit = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.GetStageLimits((ESI.SymphonyAPI.StageID)stage, out lowerLimit, out upperLimit);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetStageLimitStates(StageID stage, out bool lower, out bool upper)
        {
            bRet = false;
            lower = true;
            upper = true;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.GetStageLimitStates((ESI.SymphonyAPI.StageID)stage, out lower, out upper);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool SetStageScale(StageID stage, double scale)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetStageScale((ESI.SymphonyAPI.StageID)stage, scale);
                bRet = true;
            } while (false);
            return bRet;
        }

        public bool GetStageScale(StageID stage, out double scale)
        {
            bRet = false;
            scale = 1.00;
            do
            {
                if (m_Symphony == null)
                    break;

                scale = m_Symphony.GetStageScale((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return bRet;
        }

        public double GetStageScale(StageID stage)
        {
            bRet = false;
            double scale = 1.00;
            do
            {
                if (m_Symphony == null)
                    break;

                scale = m_Symphony.GetStageScale((ESI.SymphonyAPI.StageID)stage);
                bRet = true;
            } while (false);
            return scale;
        }
        #endregion

        #region Galvo Commands
        public bool GalvoMove(double xPos, double yPos)
        {
            bRet = false;

            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.GalvoMove(xPos, yPos);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetGalvoPosition(out double xPos, out double yPos)
        {
            bRet = false;
            xPos = 0;
            yPos = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.GetGalvoPosition(out xPos, out yPos);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool SetGalvoFlipped(bool xFlip, bool yFlip)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetGalvoFlipped(xFlip, yFlip);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetGalvoFlipped(out bool xFlip, out bool yFlip)
        {
            bRet = false;
            xFlip = false;
            yFlip = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.GetGalvoFlipped(out xFlip, out yFlip);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool SetGalvoFocalLength(int FocalLength)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetGalvoFocalLength(FocalLength);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetGalvoFocalLength(out int FocalLength)
        {
            bRet = false;
            FocalLength = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                FocalLength = m_Symphony.GetGalvoFocalLength();
                bRet = true;
            } while (false);

            return bRet;
        }

        public int GetGalvoFocalLength()
        {
            bRet = false;
            int FocalLength = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                FocalLength = m_Symphony.GetGalvoFocalLength();
                bRet = true;
            } while (false);

            return FocalLength;
        }

        public bool SetGalvoMotionDelay(int Delay)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetGalvoMotionDelay(Delay);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetGalvoMotionDelay(out int Delay)
        {
            bRet = false;
            Delay = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                Delay = m_Symphony.GetGalvoMotionDelay();
                bRet = true;
            } while (false);

            return bRet;
        }

        public int GetGalvoMotionDelay()
        {
            bRet = false;
            int Delay = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                Delay = m_Symphony.GetGalvoMotionDelay();
                bRet = true;
            } while (false);

            return Delay;
        }

        public bool SetGalvoMaxValue(double maxVal)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetGalvoMaxValue(maxVal);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetGalvoMaxValue(out double maxVal)
        {
            bRet = false;
            maxVal = 0.00;
            do
            {
                if (m_Symphony == null)
                    break;

                maxVal = m_Symphony.GetGalvoMaxValue();
                bRet = true;
            } while (false);

            return bRet;
        }

        public double GetGalvoMaxValue()
        {
            bRet = false;
            double maxVal = 0.00;
            do
            {
                if (m_Symphony == null)
                    break;

                maxVal = m_Symphony.GetGalvoMaxValue();
                bRet = true;
            } while (false);

            return maxVal;
        }
        #endregion

        #region Laser Commands

        public bool SetRepRate(int RepRate)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetRepRate(RepRate);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetRepRate(out int RepRate)
        {
            bRet = false;
            RepRate = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                RepRate = m_Symphony.GetRepRate();
                bRet = true;
            } while (false);

            return bRet;
        }

        public int GetRepRate()
        {
            bRet = false;
            int RepRate = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                RepRate = m_Symphony.GetRepRate();
                bRet = true;
            } while (false);

            return RepRate;
        }

        public bool SetGateStartDelay(int Delay)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetGateStartDelay(Delay);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetGateStartDelay(out int Delay)
        {
            bRet = false;
            Delay = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                Delay = m_Symphony.GetGateStartDelay();
                bRet = true;
            } while (false);

            return bRet;
        }

        public int GetGateStartDelay()
        {
            bRet = false;
            int Delay = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                Delay = m_Symphony.GetGateStartDelay();
                bRet = true;
            } while (false);

            return Delay;
        }

        public bool SetGateStopDelay(int Delay)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetGateStopDelay(Delay);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetGateStopDelay(out int Delay)
        {
            bRet = false;
            Delay = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                Delay = m_Symphony.GetGateStopDelay();
                bRet = true;
            } while (false);

            return bRet;
        }

        public int GetGateStopDelay()
        {
            bRet = false;
            int Delay = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                Delay = m_Symphony.GetGateStopDelay();
                bRet = true;
            } while (false);

            return Delay;
        }

        public bool SetFirstPulseDelay(int Delay)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetFirstPulseDelay(Delay);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetFirstPulseDelay(out int Delay)
        {
            bRet = false;
            Delay = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                Delay = m_Symphony.GetFirstPulseDelay();
                bRet = true;
            } while (false);

            return bRet;
        }

        public int GetFirstPulseDelay()
        {
            bRet = false;
            int Delay = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                Delay = m_Symphony.GetFirstPulseDelay();
                bRet = true;
            } while (false);

            return Delay;
        }

        public bool SetGatePolarity(bool polarity)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetGatePolarity(polarity);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetGatePolarity(out bool polarity)
        {
            bRet = false;
            polarity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                polarity = m_Symphony.GetGatePolarity();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetGatePolarity()
        {
            bRet = false;
            bool polarity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                polarity = m_Symphony.GetGatePolarity();
                bRet = true;
            } while (false);

            return polarity;
        }

        public bool SetClockPolarity(bool polarity)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetClockPolarity(polarity);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetClockPolarity(out bool polarity)
        {
            bRet = false;
            polarity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                polarity = m_Symphony.GetClockPolarity();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetClockPolarity()
        {
            bRet = false;
            bool polarity = false;
            do
            {
                if (m_Symphony == null)
                    break;

                polarity = m_Symphony.GetClockPolarity();
                bRet = true;
            } while (false);

            return polarity;
        }

        public bool SetLaserEnabled(bool Enabled)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetLaserEnabled(Enabled);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetLaserEnabled(out bool Enabled)
        {
            bRet = false;
            Enabled = false;
            do
            {
                if (m_Symphony == null)
                    break;

                Enabled = m_Symphony.GetLaserEnabled();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetLaserEnabled()
        {
            bRet = false;
            bool Enabled = false;
            do
            {
                if (m_Symphony == null)
                    break;

                Enabled = m_Symphony.GetLaserEnabled();
                bRet = true;
            } while (false);

            return Enabled;
        }

        public bool SetLaserOn(bool bLaserOn)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetLaserOn(bLaserOn);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetLaserOn(out bool bLaserOn)
        {
            bRet = false;
            bLaserOn = false;
            do
            {
                if (m_Symphony == null)
                    break;

                bLaserOn = m_Symphony.GetLaserOn();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetLaserOn()
        {
            bRet = false;
            bool bLaserOn = false;
            do
            {
                if (m_Symphony == null)
                    break;

                bLaserOn = m_Symphony.GetLaserOn();
                bRet = true;
            } while (false);

            return bLaserOn;
        }

        public bool SetLaserSimmer(bool gateSimmer, bool clockSimmer, int simmerDelay, int simmerFreq, int simmerPulseWidth)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetLaserSimmer(gateSimmer, clockSimmer, simmerDelay, simmerFreq, simmerPulseWidth);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetLaserSimmer(out bool gateSimmer, out bool clockSimmer, out int simmerDelay, out int simmerFreq, out int simmerPulseWidth)
        {
            bRet = false;
            gateSimmer = false;
            clockSimmer = false;
            simmerDelay = 0;
            simmerFreq = 0;
            simmerPulseWidth = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.GetLaserSimmer(out gateSimmer, out clockSimmer, out simmerDelay, out simmerFreq, out simmerPulseWidth);
                bRet = true;
            } while (false);

            return bRet;
        }

        #endregion

        #region Data Recorder Commands 
        public bool StartRecorder(int duration, int decimation)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.StartRecorder(duration, decimation);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool StopRecorder()
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.StopRecorder();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool ResetRecorder()
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.ResetRecorder();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetRecorderChannelData(string ChannelName, List<double> Data)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                Data = m_Symphony.GetRecorderChannelData(ChannelName);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool SelectRecorderChannels(List<string> channels)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SelectRecorderChannels(channels);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetAllRecorderChannels(List<string> channels)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                channels = m_Symphony.GetAllRecorderChannels();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetRecorderChannelUSecPerSample(string channel, out int USecPerSample)
        {
            bRet = false;
            USecPerSample = 0;
            do
            {
                if (m_Symphony == null)
                    break;

                USecPerSample = m_Symphony.GetRecorderChannelUSecPerSample(channel);
                bRet = true;
            } while (false);

            return bRet;
        }


        #endregion

        #region I/O Commands
        public bool GetDigitalInput(int inputNum, out bool value)
        {
            bRet = false;
            value = false;
            do
            {
                if (m_Symphony == null)
                    break;

                value = m_Symphony.GetDigitalInput(inputNum);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetDigitalInput(int inputNum)
        {
            bRet = false;
            bool value = false;
            do
            {
                if (m_Symphony == null)
                    break;

                value = m_Symphony.GetDigitalInput(inputNum);
                bRet = true;
            } while (false);

            return value;
        }

        public bool GetDigitalOutput(int outputNum, out bool value)
        {
            bRet = false;
            value = false;
            do
            {
                if (m_Symphony == null)
                    break;

                value = m_Symphony.GetDigitalOutput(outputNum);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetDigitalOutput(int outputNum)
        {
            bRet = false;
            bool value = false;
            do
            {
                if (m_Symphony == null)
                    break;

                value = m_Symphony.GetDigitalOutput(outputNum);
                bRet = true;
            } while (false);

            return value;
        }

        public bool SetDigitalOutput(int outputNum, bool value)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetDigitalOutput(outputNum, value);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool SetDigitalOutputs(List<int> outputs, List<bool> vals)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetDigitalOutputs(outputs, vals);
                bRet = true;
            } while (false);

            return bRet;
        }

        #endregion

        #region Control Commands
        public bool StartTask()
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.StartTask();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool EndTask()
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.EndTask();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool ClearTask()
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.ClearTask();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool AbortExecuteTask()
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.AbortExecuteTask();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool StartExecuteTask()
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.StartExecuteTask();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool FinishExecuteTask()
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.FinishExecuteTask();
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool SetPathTolerance(double velTolerance, double accTolerance)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetPathTolerance(velTolerance, accTolerance);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool SetTaskProcessingAxis(AxisID axis)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.SetTaskProcessingAxis((ESI.SymphonyAPI.AxisID)axis);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool GetTaskProcessingAxis(out AxisID axis)
        {
            bRet = false;
            axis = AxisID.Z_STAGE;
            do
            {
                if (m_Symphony == null)
                    break;

                axis = (AxisID)m_Symphony.GetTaskProcessingAxis();
                bRet = true;
            } while (false);

            return bRet;
        }

        public AxisID GetTaskProcessingAxis()
        {
            bRet = false;
            AxisID axis = AxisID.Z_STAGE;
            do
            {
                if (m_Symphony == null)
                    break;

                axis = (AxisID)m_Symphony.GetTaskProcessingAxis();
                bRet = true;
            } while (false);

            return axis;
        }
        #endregion

        #region Recipe Commands
        public bool LinePath(double startX, double startY, double endX, double endY, double velocity)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.LinePath(startX, startY, endX, endY, velocity);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool LinePathWithoutLasing(double startX, double startY, double endX, double endY, double velocity)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.LinePathWithoutLasing(startX, startY, endX, endY, velocity);
                bRet = true;
            } while (false);

            return bRet;
        }

        public bool ArcPath(double startX, double startY, double endX, double endY, double radius, double velocity)
        {
            bRet = false;
            do
            {
                if (m_Symphony == null)
                    break;

                m_Symphony.ArcPath(startX, startY, endX, endY, radius, velocity);
                bRet = true;
            } while (false);

            return bRet;
        }

        #endregion

        #region Misc Commands
        public bool GetFPGAVersion(out string version)
        {
            bRet = false;
            version = "";
            do
            {
                if (m_Symphony == null)
                    break;

                version = m_Symphony.GetFPGAVersion();
                bRet = true;
            } while (false);

            return bRet;
        }

        public string GetFPGAVersion()
        {
            bRet = false;
            string version = "";
            do
            {
                if (m_Symphony == null)
                    break;

                version = m_Symphony.GetFPGAVersion();
                bRet = true;
            } while (false);

            return version;
        }

        public bool GetFirmwareVersion(out string version)
        {
            bRet = false;
            version = "";
            do
            {
                if (m_Symphony == null)
                    break;

                version = m_Symphony.GetFirmwareVersion();
                bRet = true;
            } while (false);

            return bRet;
        }

        public string GetFirmwareVersion()
        {
            bRet = false;
            string version = "";
            do
            {
                if (m_Symphony == null)
                    break;

                version = m_Symphony.GetFirmwareVersion();
                bRet = true;
            } while (false);

            return version;
        }

        public bool GetSerialNumber(out string SerialNum)
        {
            bRet = false;
            SerialNum = "";
            do
            {
                if (m_Symphony == null)
                    break;

                SerialNum = m_Symphony.GetSerialNumber();
                bRet = true;
            } while (false);

            return bRet;
        }

        public string GetSerialNumber()
        {
            bRet = false;
            string SerialNum = "";
            do
            {
                if (m_Symphony == null)
                    break;

                SerialNum = m_Symphony.GetSerialNumber();
                bRet = true;
            } while (false);

            return SerialNum;
        }
        #endregion
    }
}
