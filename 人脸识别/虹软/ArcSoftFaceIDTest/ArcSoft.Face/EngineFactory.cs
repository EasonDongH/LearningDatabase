using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ArcSoft.Face
{
    /// <summary>
    /// 引擎工厂
    /// </summary>
    public class EngineFactory
    {

        private static IntPtr hEngine;

        private const uint video = 0x00000000;
        private const uint image = 0xFFFFFFFF;

        public static uint Video { get { return video; } }

        public static uint Image { get { return image; } }

        /// <summary>
        /// 获得引擎Handler
        /// </summary>
        /// <param name="mode">模式（图像/视频流）</param>
        /// <param name="orientPriority">检测方向的优先级</param>
        /// <param name="detectFaceScaleVal">数值化的最小人脸尺寸</param>
        /// <returns></returns>
        public static IntPtr GetEngineInstance(uint mode, DetectionOrientPriority orientPriority, int detectFaceScaleVal = 16)
        {

            hEngine = IntPtr.Zero;
            try
            {
                ResultCode result = (ResultCode)ASFAPI.ASFInitEngine(mode, (int)orientPriority, detectFaceScaleVal, 5, (int)(EngineMode.ASF_FACE_DETECT | EngineMode.ASF_FACERECOGNITION | EngineMode.ASF_GENDER | EngineMode.ASF_AGE | EngineMode.ASF_FACE3DANGLE | EngineMode.ASF_LIVENESS), ref  hEngine);
                if (result == ResultCode.MOK)
                {
                    return hEngine;
                }
                else
                {
                    throw new Exception(result.ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 释放引擎Handler
        /// </summary>
        /// <returns></returns>
        public static bool DisposeEngine()
        {
            if (hEngine != null && hEngine != IntPtr.Zero)
            {
                try
                {
                    ResultCode result = (ResultCode)ASFAPI.ASFUninitEngine(hEngine);
                    if (result == ResultCode.MOK)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception(result.ToString());
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //Marshal.FreeHGlobal(hEngine);
                }
            }
            return true;
        }
    }
}
