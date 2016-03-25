using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace USBCamera
{  
#region structs and enums
 
#region HVDAILT
    public enum HVTYPE
    {
        UNKNOWN_TYPE = -1, ///< Invalid devcie type. 	
        HV1300UCTYPE = 0,
        HV2000UCTYPE = 1,
        HV1301UCTYPE = 2,
        HV2001UCTYPE = 3,
        HV3000UCTYPE = 4,
        HV1300UMTYPE = 5,
        HV1302UCTYPE = 6,
        HV2002UCTYPE = 7,
        HV3102UCTYPE = 8,
        HV1302UMTYPE = 9,
        HV1300FCTYPE = 10,
        HV2000FCTYPE = 11,
        HV3100FCTYPE = 12,
        HV1300FMTYPE = 13,
        HV1303UCTYPE = 14,
        HV2003UCTYPE = 15,
        HV3103UCTYPE = 16,
        HV1303UMTYPE = 17,
        SV1300FMTYPE = 18,
        SV1300FCTYPE = 19,
        SV1310FCTYPE = 20,
        SV1310FMTYPE = 21,
        SV1311FCTYPE = 22,
        SV1311FMTYPE = 23,
        SV400FCTYPE  = 24,
        SV400FMTYPE  = 25,
        DH1394FXTYPE = 26,
        SV1410FCTYPE = 27,
        SV1410FMTYPE = 28,
        SV1420FCTYPE = 29,
        SV1420FMTYPE = 30,
        SV2000FCTYPE = 31,
        SV2000FMTYPE = 32,
        SV1400FCTYPE = 33,
        SV1400FMTYPE = 34,
        HV1350UCTYPE = 35,
        HV2050UCTYPE = 36,
        HV3150UCTYPE = 37,
        HV1350UMTYPE = 38,
        HV1360UCTYPE = 39,
        HV2060UCTYPE = 40,
        HV3160UCTYPE = 41,
        HV1360UMTYPE = 42,

        HV1351UCTYPE = 56,
        HV2051UCTYPE = 57,
        HV3151UCTYPE = 58,
        HV1351UMTYPE = 59,
        GV400UCTYPE  = 60,
        GV400UMTYPE  = 61,
        HV5051UCTYPE = 62,
        HV5051UMTYPE = 63
    }

    public enum HV_COLOR_CODE
    {
        COLOR_MONO8             = 0,    ///< Y only, Y=8bits
        COLOR_YUV8_4_1_1        = 1,    ///< Y=U=V=8bits, non compressed
        COLOR_YUV8_4_2_2        = 2,    ///< Y=U=V=8bits, non compressed
        COLOR_YUV8_4_4_4        = 3,    ///< Y=U=V=8bits, non compressed
        COLOR_RGB8              = 4,    ///< RGB 8 format, each component has 8bit data
        COLOR_MONO16            = 5,    ///< Y only, Y=16bits, non compressed(unsigned integer)
        COLOR_RGB16             = 6,    ///< RGB 16 format, each component has 16bit data
        COLOR_SIGNED_MONO16     = 7,    ///< Y only, Y=16bits, non compressed(signed integer)
        COLOR_SIGNED_RGB16      = 8,    ///< R=G=B=16bits, non compressed(signed integer)
        COLOR_RAW8              = 9,    ///< RAW 8 format, each pixel has 8bit data
        COLOR_RAW16             = 10,   ///< RAW 16 format, each pixel has 16bit data
        COLOR_MONO10            = 128,  ///< Y only, each pixel has 16bit data, the low 10bit is valid
        COLOR_MONO10_NORMALIZED = 129,  ///< Reserved
        COLOR_MONO10_PACKED     = 130,  ///< Y only, packed format, each pixel has 10bit data 
        COLOR_RAW10             = 131,  ///< RAW 10 format, each pixel has 16bit data, the low 10bit is valid
        COLOR_RAW10_NORMALIZED  = 132,  ///< Reserved
        COLOR_RAW10_PACKED      = 133,  ///< RAW 10 packed format, each pixel has 10bit data
        COLOR_MONO12            = 134,  ///< Y only, each pixel has 16bit data, the low 12bit is valid
        COLOR_MONO12_NORMALIZED = 135,  ///< Reserved
        COLOR_MONO12_PACKED     = 136,  ///< Y only, packed format, each pixel has 12bit data 
        COLOR_RAW12             = 137,  ///< RAW 12 format, each pixel has 16bit data, the low 12bit is valid
        COLOR_RAW12_NORMALIZED  = 138,  ///< Reserved
        COLOR_RAW12_PACKED      = 139   ///< RAW 12 packed format, each pixel has 12bit data
    }

    public enum HV_COLOR_FILTER
    {
        COLOR_FILTER_RG_GB = 0, ///< RGB primary color filter (RG/GB)
        COLOR_FILTER_GB_RG = 1, ///< RGB primary color filter (GB/RG)
        COLOR_FILTER_GR_BG = 2, ///< RGB primary color filter (GR/BG)
        COLOR_FILTER_BG_GR = 3  ///< RGB primary color filter (BG/GR)
    }

    public enum HV_RESOLUTION
    {
        RES_MODE0 = 0,  ///< Resolution 0
        RES_MODE1 = 1,  ///< Resolution 1
        RES_MODE2 = 2,  ///< Resolution 2
        RES_MODE3 = 3,  ///< Resolution 3
        RES_MODE4 = 4,  ///< Resolution 4
        RES_MODE5 = 5,  ///< Resolution 5
        RES_MODE6 = 6   ///< Resolution 6
    }

    public enum HV_SNAP_MODE
    {
        CONTINUATION            = 0,    ///< Acquire images continuously
        TRIGGER                 = 1,    ///< Acquiring image controlled by standard trigger
        TRIGGER_EDGE            = 2,    ///< Acquiring image controlled by edge event triggering
        TRIGGER_LEVEL           = 3,    ///< Acquiring image controlled by level triggering
        TRIGGER_LEVEL_STANDARD  = 4     ///< Acquiring image controlled by standard level triggering
    }

    public enum HV_POLARITY
    {
        LOW  = 0,
        HIGH = 1
    }

    public enum HV_SNAP_SPEED
    {
        NORMAL_SPEED = 0,   ///< Acquiring images at normal speed
        HIGH_SPEED   = 1    ///< Acquiring images at high speed
    }

    public enum HV_ADC_CONTROL
    {
        ADC_BITS                        = 0,    ///< Controlling bits that are used for A/D conversion
        ADC_BLKLEVEL_CAL                = 1,    ///< Enable/disable to control the black level parameter
        ADC_BLKLEVEL_CAL_REDCHANNEL     = 0x10, ///< Controlling the red channel of the black level
        ADC_BLKLEVEL_CAL_GREENCHANNEL1  = 0x11, ///< Controlling the green channel 1 of the black level
        ADC_BLKLEVEL_CAL_GREENCHANNEL2  = 0x12, ///< Controlling the green channel 2 of the black level
        ADC_BLKLEVEL_CAL_BLUECHANNEL    = 0x13, ///< Controlling the blue channel of the black level
    }

    public enum HV_ADC_LEVEL
    {
        ADC_LEVEL0 = 0,    ///< Level 0
        ADC_LEVEL1 = 1,    ///< Level 1
        ADC_LEVEL2 = 2,    ///< Level 2
        ADC_LEVEL3 = 3,    ///< Level 3
        ADC_LEVEL4 = 4     ///< Level 4
    }

    public enum HV_CHANNEL
    {
        RED_CHANNEL     = 0x10, ///< Red channel
        GREEN_CHANNEL1  = 0x11,	///< Green channe1
        GREEN_CHANNEL2  = 0x12, ///< Green channe2
        BLUE_CHANNEL    = 0x13  ///< Blue channel
    }

    public enum HV_AEC_CONTROL
    {
        AEC_EXPOSURE_TIME = 1,  ///< Controlling exposure by exposure coefficient	
        AEC_SHUTTER_SPEED = 2,  ///< Controlling the shutter speed
        AEC_SHUTTER_UNIT  = 3	///< Controlling the unit of the shutter speed
    }

    public enum SHUTTER_UNIT_VALUE
    {
        SHUTTER_US = 0,    ///< The unit of the shutter speed is microsecond
        SHUTTER_MS = 1,    ///< The unit of the shutter speed is millisecond
    }

    public enum HV_MIRROR_DIRECTION
    {
        VERT_DIR = 1,    ///< performing vertical mirror during image acquisition
        HOR_DIR  = 2,    ///< performing horizontal mirror during image acquisition
        FULL_DIR = 3     ///< performing vertical and horizontal mirror during image acquisition
    }

    public enum HV_DEVICE_INFO
    {
        DESC_DEVICE_TYPE                = 0,  ///< the device type of a camera
        DESC_RESOLUTION                 = 1,  ///< the resolution of a camera
        DESC_DEVICE_MARK                = 2,  ///< the device mark of a camera
        DESC_DEVICE_SERIESNUM           = 3,  ///< the serial number of a camera
        DESC_DEVICE_BLANKSIZE           = 4,  ///< the available range of blanking interval
        DESC_DEVICE_CHIPID              = 5,  ///< the device chip id
        DESC_DEVICE_HARDWARE_VERSION    = 6,  ///< the firmware version of camera
        DESC_DEVICE_BAYER_LAYOUT        = 11  ///< the bayer layout of image
    }

    public enum HV_PERIDEV_CONTROL
    {
        PERIDEV_BICOLOR_LAMP1   = 0,    ///< control the lamp1
        PERIDEV_BICOLOR_LAMP2   = 1,    ///< control the lamp2
        PERIDEV_IR_EMITTER      = 2,    ///< control the IR Emitter
        PERIDEV_LED             = 3,    ///< control the LED
        PERIDEV_ARRIVE_CLEAR    = 4,    ///< control the clear of arrive
        PERIDEV_LED1            = 5,    ///< control the LED1
        PERIDEV_LED2            = 6		///< control the LED2
    }

    public enum HV_COMMAND_CODE
    {
        CMD_RESERVED0                       = 0x00, ///< Reserved
        CMD_RESERVED1                       = 0x01, ///< Reserved
        CMD_RESERVED2                       = 0x02, ///< Reserved
        CMD_RESERVED3                       = 0x03, ///< Reserved

        CMD_SET_STROBE_SIGNAL_MODE          = 0x25, ///< Set the strobe signal mode(HV_SIGNAL_MODE)
        CMD_SET_EXPOSURE_MODE               = 0x26, ///< Set the exposure mode(HV_EXPOSURE_MODE)
        CMD_SET_ROW_NOISE_CORR_CONTROL      = 0x27, ///< Set the row noise correction control(HV_NOISECORR_CONTROL)
        CMD_RESET_SENSOR                    = 0x28, ///< Reset Sensor(HV_SENSOR_STATUS)
        CMD_RESERVED29                      = 0x29, ///< Reserved
        CMD_RESERVED30                      = 0x30, ///< Reserved

        CMD_SET_COLOR_CODE                  = 0x31, ///< Set the image color code (HV_COLOR_CODE)
        CMD_GET_COLOR_CODE                  = 0x32, ///< Get the image color code (HV_COLOR_CODE)

        CMD_GET_IMAGEINFO_ID_FRAME_COUNT    = 0x33, ///< Get the frame count from image info (DWORD)
        CMD_GET_IMAGEINFO_ID_FRAME_INTERVAL = 0x34, ///< Get the frame interval from image info (DWORD)
        CMD_GET_IMAGEINFO_ID_SENSOR_TYPE    = 0x35, ///< Get the sensor type from image info (WORD)

        CMD_ENABLE_AUTO_GAIN_CTRL           = 0x36, ///< Enable or disable AGC(BOOL)
        CMD_GET_AGC_STATUS                  = 0x37, ///< Get the status of AGC:enable or disable? (BOOL)

        CMD_ENABLE_AUTO_SHUTTER_CTRL        = 0x38, ///< Enable or disable AEC(BOOL)
        CMD_GET_AEC_STATUS                  = 0x39, ///< Get the status of AEC:enable or disable? (BOOL)

        CMD_SET_AA_GRAY_VALUE               = 0x40, ///< Set the expect gray value for AEC&AGC (DWORD)
        CMD_GET_AA_GRAY_VALUE               = 0x41, ///< Get the expect gray value for AEC&AGC (DWORD)

        CMD_SET_AA_ROI                      = 0x42, ///< Set the region of interest for AEC&AGC (HV_RECT)
        CMD_GET_AA_ROI                      = 0x43, ///< Get the region of interest for AEC&AGC (HV_RECT)

        CMD_SET_AA_LIGHT_ENVIRONMENTS       = 0x44, ///< Set the light environments for AEC&AGC (HV_AA_LIGHT_ENVIRONMENTS)
        CMD_GET_AA_LIGHT_ENVIRONMENTS       = 0x45, ///< Get the light environments for AEC&AGC (HV_AA_LIGHT_ENVIRONMENTS)

        CMD_SET_AGC_ADJUST_RANGE            = 0x46, ///< Set the adjust range of AGC (HV_RANGE)
        CMD_GET_AGC_ADJUST_RANGE            = 0x47, ///< Get the maximum range to adjust (HV_RANGE)

        CMD_SET_AEC_ADJUST_RANGE            = 0x48, ///< Set the adjust range of AEC (HV_RANGE)
        CMD_GET_AEC_ADJUST_RANGE            = 0x49, ///< Get the maximum range to adjust (HV_RANGE)

        CMD_GET_AGC_CURRENT_VALUE           = 0x50, ///< Get the current value of AGC (DWORD)
        CMD_GET_AEC_CURRENT_VALUE           = 0x51, ///< Get the current value of AEC (DWORD)

        CMD_ENABLE_AUTO_WHITEBALANCE        = 0x52, ///< Enable or disable AWB (BOOL)
        CMD_GET_AUTO_WHITEBALANCE_STATUS    = 0x53, ///< Get the status of AWB:enable or disable? (BOOL)

        CMD_ENABLE_COLOR_CORRECTION         = 0x54, ///< Enable or disable color correction (BOOL)
        CMD_GET_COLOR_CORRECTION_STATUS     = 0x55, ///< Get the status of color correction:enable or disable? (BOOL)

        CMD_GET_SNAPSPEED_COEFF_RANGE       = 0x56, ///< Get the adjust range of the snap speed coefficient (HV_RANGE)
        CMD_SET_SNAPSPEED_COEFFICIENT       = 0x57, ///< Set the coefficient of the snap speed(DWORD)
        CMD_GET_SNAPSPEED_COEFFICIENT       = 0x58, ///< Get the coefficient of the snap speed(DWORD)

        CMD_SPEC_FUN_INTERFACE1             = 0x80, ///< special function(HV_INTERFACE1_ID)

        CMD_HVAPI_CONTROL                   = 0x100 ///< function defined by HV_CONTROL_CODE
    }

    public struct HV_RECT
    {
        public uint left;      ///< the left of an image
        public uint top;       ///< the top of an image
        public uint right;     ///< the right of an image
        public uint bottom;    ///< the bottom of an image
    }

    public enum HV_AA_LIGHT_ENVIRONMENTS
    {
        NATURE_LIGHT = 0,   ///< direct current or natural light 
        AC_50HZ      = 1,   ///< 50Hz alternating current
        AC_60HZ      = 2    ///< 60Hz alternating current
    }

    public struct HV_RANGE
    {
        public int nMinValue;	///< the min value
        public int nMaxValue;	///< the max value
    }

    public enum HV_INTERFACE1_ID
    {
        SCOLOR_MODE = 4,
    }

    public enum HV_SIGNAL_TYPE
    {
        SIGNAL_IMPULSE  = 0,
        SIGNAL_LEVEL    = 1
    }

    public struct HV_SIGNAL_MODE
    {
        public int Polarity;   ///< 0:LOW ;1: HIGH
        public int Mode;       ///< 0:SIGNAL_IMPULSE; 1: SIGNAL_LEVEL
    }

    public enum HV_EXPOSURE_MODE
    {
        SEQUENCE     = 0,   ///< the sequence exposure mode 
        SIMULTANEITY = 1    ///< the simultaneity exposure mode
    }

    public enum HV_SENSOR_STATUS
    {
        RESET = 0         ///< reset sensor
    }

    public enum HV_NOISECORR_CONTROL
    {
        NOISECORR_ENABLE  = 0,
        NOISECORR_DISABLE = 1
    }

    public enum HVSTATUS
    {
        STATUS_OK                       = 0,
        STATUS_NO_DEVICE_FOUND          = -1,
        STATUS_DEVICE_HANDLE_INVALID    = -2,
        STATUS_HW_DEVICE_TYPE_ERROR     = -3,
        STATUS_HW_INIT_ERROR            = -4,
        STATUS_HW_RESET_ERROR           = -5,
        STATUS_NOT_ENOUGH_SYSTEM_MEMORY = -6,
        STATUS_HW_IO_ERROR              = -7,
        STATUS_HW_IO_TIMEOUT            = -8,
        STATUS_HW_ACCESS_ERROR          = -9,
        ////////////////////////////////////////////
        STATUS_OPEN_DRIVER_FAILED       = -10,
        STATUS_NOT_SUPPORT_INTERFACE    = -11,
        STATUS_PARAMETER_INVALID        = -12,
        STATUS_PARAMETER_OUT_OF_BOUND   = -13,
        STATUS_IN_WORK                  = -14,
        STATUS_NOT_OPEN_SNAP            = -15,
        STATUS_NOT_START_SNAP           = -16,
        STATUS_FILE_CREATE_ERROR        = -17,
        STATUS_FILE_INVALID             = -18,
        STATUS_NOT_START_SNAP_INT       = -19,
        STATUS_INTERNAL_ERROR           = -20,
    }
        
    public struct HV_SNAP_INFO
    {
        public IntPtr  pHandle; ///<Handle to current camera
        public int     nDevice; ///<Index of working camera; the index starts with 1
        public int     nIndex;  ///<Index of buffer used by current camera; the index starts with 0
        public IntPtr  pParam;  ///<Pointer to a parameter defined by user
    }

    public delegate bool HV_SNAP_PROC(ref HV_SNAP_INFO Info);

    public struct HV_CHECK_PARAM
    {
        public Byte byParam1;
        public Byte byParam2;
        public Byte byParam3;
        public Byte byParam4;
    }

    public struct HV_INTERFACE1_CONTEXT
    {
        public HV_INTERFACE1_ID ID;
        public int              nVal;
    }

    public enum HV_CONTROL_CODE
    {
        ORD_QUERY_LAST_STATUS_PRESENCE  = 0x0000000C,
        ORD_GET_LAST_STATUS             = 0x0000000E
    }

    public struct HVAPI_CONTROL_PARAMETER
    {
        public HV_CONTROL_CODE  code;
        public IntPtr           pInBuf;         ///< the input buffer
        public int              nInBufSize;     ///< the size of input buffer
        public IntPtr           pOutBuf;        ///< the output buffer      
        public int              nOutBufSize;    ///< the size of output buffer
        public IntPtr           pBytesRet;      ///< return the actual size of pOutBuf(bytes)
    }

    public struct HV_RES_QUERY_LAST_STATUS_PRESENCE
    {
        public int Reserved;   ///< Reserved
        public int Transfer;   ///< Last transfer status function flag. 0:disable: 1:enable.
        public int Snap;       ///< Last snap status function flag. 0:disable: 1:enable.
        public int Control;    ///< Last control status function flag. 0:disable: 1:enable.
    }

    public enum HV_LAST_STATUS
    {
        HV_LAST_STATUS_ERROR_CONTROL    = 0, ///< extended error information about HVSTATUS
        HV_LAST_STATUS_SNAP             = 1, ///< snap status
        HV_LAST_STATUS_TRANSFER         = 2, ///< transfer status about callback function, see HV_SNAP_PROC	
    }

    public struct HV_ARG_GET_LAST_STATUS
    {
        public HV_LAST_STATUS type;    ///< The type of camera's working status, reference to HV_LAST_STATUS
    }

    public enum HV_LAST_STATUS_RETURNCODE : uint
    {
        STATUS_BAD_FRAME = 0xE0040005,	///< the code for bad frames
    }

    public struct HV_RES_GET_LAST_STATUS
    {
        public HV_LAST_STATUS_RETURNCODE status;     ///< Last status
    }
#endregion

#region Raw2Rgb
    public enum HV_CONVERT_CODE
    {
        CONV_RAW2RGB                = 0,
        CONV_GET_WHITEBALANCE_VALUE = 1
    }

    public enum HV_BAYER_CONVERT_TYPE
    {
        BAYER2RGB_ZHC,
        BAYER2RGB_NEIGHBOUR,
        BAYER2RGB_BILINER,
        BAYER2RGB_PATTERN,
        BAYER2RGB_EDGESENSING,
        BAYER2RGB_RF,
        BAYER2RGB_PIXELGROUPING,
        BAYER2RGB_NEIGHBOUR1,
        BAYER2RGB_ADAPTIVE,
        BAYER2RGB_RESERVERED2,
        BAYER2RGB_RESERVERED3
    }

    public struct HV_CONVERT_RAW2RGB
    {
        public byte[]                   pDestData;
        public HV_COLOR_CODE            ccDestColorCode;
        public int                      nDestBitCount;
        public int                      nDestDataDepth;
        public byte[]                   pSrceData;
        public HV_COLOR_CODE            ccSrceColorCode;
        public int                      nSrceBitCount;
        public int                      nSrceDataDepth;
        public HV_COLOR_FILTER          cfFilter;
        public int                      nWidth;
        public int                      nHeight;
        public HV_BAYER_CONVERT_TYPE    cvType;
        public byte[]                   pLutR;
        public byte[]                   pLutG;
        public byte[]                   pLutB;
        public bool                     bIsFlip;
    }

    public struct HV_GET_WHITEBALANCE_VALUE
    {
        public byte[]           pData;
        public HV_COLOR_CODE    ccColorCode;
        public int              nBitCount;
        public int              nDataDepth;
        public int              nWidth;
        public int              nHeight;
        public IntPtr           pValueR;
        public IntPtr           pValueG;
        public IntPtr           pValueB;
    }

    public enum HV_BAYER_LAYOUT
    {
        BAYER_GB = 1,    ///< start from GB
        BAYER_GR = 2,    ///< start from GR
        BAYER_BG = 3,    ///< start from BG
        BAYER_RG = 4     ///< start from RG
    }

    public enum HV_ILLUMINANT
    {
        DAYLIGHT,
        FLUORESCENT,
        INCANDESCENT,
    }
#endregion
   
#endregion



    public class API
    {
#region HVDAILT
        /////////////////////////////////////////////
        // Common methods
        /////////////////////////////////////////////
        static public bool HV_SUCCESS(HVSTATUS Status)
        {
            if (Status == HVSTATUS.STATUS_OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public HVSTATUS HV_VERIFY(HVSTATUS Status)
        {
#if DEBUG
            if (Status != HVSTATUS.STATUS_OK)
            {
                MessageBox.Show(HVGetErrorString(Status), "Error", MessageBoxButtons.OK);
            }
#endif

            return Status;
        }

        static public HVSTATUS HV_MESSAGE(HVSTATUS Status)
        {
            if (Status != HVSTATUS.STATUS_OK)
            {
                MessageBox.Show(HVGetErrorString(Status), "Error message", MessageBoxButtons.OK);
            }

            return Status;
        }

        /////////////////////////////////////////////
        // Base methods
        /////////////////////////////////////////////
        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS BeginHVDevice(int nDevice, ref IntPtr pHandle);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS EndHVDevice(IntPtr pHandle);

        /////////////////////////////////////////////
        // Setting methods
        /////////////////////////////////////////////
        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVSetResolution(IntPtr pHandle, HV_RESOLUTION Resolution);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVSetOutputWindow(IntPtr pHandle, int nXStart, int nYStart, int nWidth, int nHeight);
        
        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVSetBlanking(IntPtr pHandle, int nHor, int nVert);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVSetSnapMode(IntPtr pHandle, HV_SNAP_MODE Mode);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVSetTriggerPolarity(IntPtr pHandle, HV_POLARITY Polarity);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVSetStrobePolarity(IntPtr pHandle, HV_POLARITY Polarity);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVSetSnapSpeed(IntPtr pHandle, HV_SNAP_SPEED Speed);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVEnableVideoMirror(IntPtr pHandle, HV_MIRROR_DIRECTION Dir, Boolean bEnable);

        /////////////////////////////////////////////
        // Control methods
        /////////////////////////////////////////////
        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVADCControl(IntPtr pHandle, Byte byParam, int lValue);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVAGCControl(IntPtr pHandle, Byte byParam, int lValue);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVAECControl(IntPtr pHandle, Byte byParam, int lValue);

        /////////////////////////////////////////////
        // Getting methods
        /////////////////////////////////////////////
        [DllImport("HVDAILT.dll")]
        public static extern string HVGetErrorString(HVSTATUS Status);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVGetDeviceTotal(ref int pNumber);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVGetDeviceInfo(IntPtr pHandle, HV_DEVICE_INFO Param, IntPtr pContext, ref int pSize);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVCheckDevice(IntPtr pHandle, HV_CHECK_PARAM Param, ref Boolean bStatus);

        /////////////////////////////////////////////
        // Collection methods
        /////////////////////////////////////////////
        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVSnapShot(IntPtr pHandle, IntPtr[] ppBuffer, int nSum);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVOpenSnap(IntPtr pHandle, HV_SNAP_PROC SnapFunc, IntPtr pParam);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVCloseSnap(IntPtr pHandle);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVStartSnap(IntPtr pHandle, IntPtr[] ppBuffer, int nSum);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVStopSnap(IntPtr pHandle);

        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVTriggerShot(IntPtr pHandle);

        /////////////////////////////////////////////
        // Memery methods
        /////////////////////////////////////////////    
        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVDeviceMemRead(IntPtr pHandle, uint nOffset, ref Byte[] pBuffer, uint nLength);
        
        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVDeviceMemWrite(IntPtr pHandle, uint nOffset, ref Byte[] pBuffer, uint nLength);

        /////////////////////////////////////////////
        // Command methods
        /////////////////////////////////////////////
        [DllImport("HVDAILT.dll")]
        public static extern HVSTATUS HVCommand(IntPtr pHandle, HV_COMMAND_CODE CommandCode, IntPtr pContext, IntPtr pLength);
#endregion
       
#region Raw2Rgb
        [DllImport("Raw2Rgb.dll")]
        public static extern void Raw12PackedToRaw16(byte[] pInBuf, byte[] pOutBuf, int nWidth, int nHeight);

        [DllImport("Raw2Rgb.dll")]
        public static extern void Raw10PackedToRaw16(byte[] pInBuf, byte[] pOutBuf, int nWidth, int nHeight);

        [DllImport("Raw2Rgb.dll")]
        public static extern void ROIColorCorrection(byte[] pImg, int roi_left, int roi_top, int roi_wid, int roi_hei, int nImgWid, int nImgHei);

        [DllImport("Raw2Rgb.dll")]
        public static extern HVSTATUS HVRotate90CW8B(byte[] pInputBuffer, int nWidth, int nHeight, byte[] pOutputBuffer);

        [DllImport("Raw2Rgb.dll")]
        public static extern HVSTATUS HVRotate90CCW8B(byte[] pInputBuffer, int nWidth, int nHeight, byte[] pOutputBuffer);

        [DllImport("Raw2Rgb.dll")]
        public static extern HVSTATUS HVBrightness(byte[] pInputBuffer, int nImagesize, int nFactor, byte[] pOutputBuffer);

        [DllImport("Raw2Rgb.dll")]
        public static extern HVSTATUS HVContrast(byte[] pInputBuffer, int nImagesize, int nFactor, byte[] pOutputBuffer);

        [DllImport("Raw2Rgb.dll")]
        public static extern HVSTATUS HVSharpen24B(byte[] pInputBuffer, int nWidth, int nHeight, float factor, byte[] pOutputBuffer);

        [DllImport("Raw2Rgb.dll")]
        public static extern void HVConvert(HV_CONVERT_CODE ConvertCode, IntPtr pContext, ref int Length);

        [DllImport("Raw2Rgb.dll")]
        public static extern void ConvertBayer2Rgb(byte[] pDest, byte[] pSrce, int nWid, int nHei, HV_BAYER_CONVERT_TYPE cvtype,
                              byte[] pLutR, byte[] pLutG, byte[] pLutB, bool bIsFlip, HV_BAYER_LAYOUT Layout);

        [DllImport("Raw2Rgb.dll")]
        public static extern void GetWhiteBalanceRatio(byte[] pSrce, int nWid, int nHei, ref double pRatioR, ref double pRatioG, ref double pRatioB);

        [DllImport("Raw2Rgb.dll")]
        public static extern void SetGammaLut(byte[] pLutGamma, double dGammaRatio);

        [DllImport("Raw2Rgb.dll")]
        public static extern void DetectDeadPixel(byte[] pRawImgBuf, byte[] pBadPixelPosBuf, int nImgWid, int nImgHei);

        [DllImport("Raw2Rgb.dll")]
        public static extern void EraseDeadPixel(byte[] pRawImgBuf, byte[] pBadPixelPosBuf, int nXPos, int nYPos, int nImgWid, int nImgHei, int nBadPixelBufWid, int nBadPixelBufHei);

        [DllImport("Raw2Rgb.dll")]
        public static extern void GetPatternNoise(byte[] pRawImgBuf, int[] pPatternBuf, int nPatternWid, int nPatternHei);

        [DllImport("Raw2Rgb.dll")]
        public static extern void AvgPatternNoise(int[] pPatternBuf, int nPatternWid, int nPatternHei, int nAvgTimes);

        [DllImport("Raw2Rgb.dll")]
        public static extern void FixPatternNoise(byte[] pRawImgBuf, int[] pPatternBuf, int nXPos, int nYPos, int nImgWid, int nImgHei, int nPatternWid, int nPatternHei);
        
        [DllImport("Raw2Rgb.dll")]
        public static extern void SetBadPixelThreshold(int BadPixelThreshold);
#endregion
    }
}