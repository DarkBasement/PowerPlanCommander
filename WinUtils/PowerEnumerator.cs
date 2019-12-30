using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class PowerEnumerator
    {
        //private static Guid NO_SUBGROUP_GUID = new Guid("fea3413e-7e05-4911-9a71-700331f1c294");
        //private static Guid GUID_DISK_SUBGROUP = new Guid("0012ee47-9041-4b5d-9b77-535fba8b1442");
        //private static Guid GUID_SYSTEM_BUTTON_SUBGROUP = new Guid("4f971e89-eebd-4455-a8de-9e59040e7347");
        //private static Guid GUID_PROCESSOR_SETTINGS_SUBGROUP = new Guid("54533251-82be-4824-96c1-47b60b740d00");
        //private static Guid GUID_VIDEO_SUBGROUP = new Guid("7516b95f-f776-4464-8c53-06167f40cc99");
        //private static Guid GUID_BATTERY_SUBGROUP = new Guid("e73a048d-bf27-4f12-9731-8b2076e8891f");
        //private static Guid GUID_SLEEP_SUBGROUP = new Guid("238C9FA8-0AAD-41ED-83F4-97BE242C8F20");
        //private static Guid GUID_PCIEXPRESS_SETTINGS_SUBGROUP = new Guid("501a4d13-42af-4429-9fd1-a8218c268e20");

        //[DllImport("powrprof.dll")]
        //static extern uint PowerEnumerate(
        //    IntPtr RootPowerKey,
        //    IntPtr SchemeGuid,
        //    ref Guid SubGroupOfPowerSetting,
        //    uint AccessFlags,
        //    uint Index,
        //    ref Guid Buffer,
        //    ref uint BufferSize);

        [DllImport("PowrProf.dll", EntryPoint = "PowerEnumerate")]
        public static extern UInt32 PowerEnumerate(IntPtr RootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, UInt32 AcessFlags, UInt32 Index, ref Guid Buffer, ref UInt32 BufferSize);

        [DllImport("powrprof.dll")]
        static extern uint PowerGetActiveScheme(
            IntPtr UserRootPowerKey,
            ref IntPtr ActivePolicyGuid);

        [DllImport("powrprof.dll")]
        static extern uint PowerSetActiveScheme(
            IntPtr UserRootPowerKey,
            ref Guid SchemeGuid);

        //[DllImport("powrprof.dll")]
        //static extern uint PowerReadACValue(
        //    IntPtr RootPowerKey,
        //    IntPtr SchemeGuid,
        //    IntPtr SubGroupOfPowerSettingGuid,
        //    ref Guid PowerSettingGuid,
        //    ref int Type,
        //    ref IntPtr Buffer,
        //    ref uint BufferSize
        //    );

        [DllImport("powrprof.dll", CharSet = CharSet.Unicode, EntryPoint = "PowerReadFriendlyName")]
        public static extern UInt32 PowerReadFriendlyName(IntPtr RootPowerKey, ref Guid SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, IntPtr PowerSettingGuid, StringBuilder Buffer, ref UInt32 BufferSize);


        [DllImport("kernel32.dll")]
        static extern IntPtr LocalFree(
            IntPtr hMem
            );

        private const uint ERROR_MORE_DATA = 234;

        public enum AccessFlags : uint
        {
            ACCESS_SCHEME = 16,
            ACCESS_SUBGROUP = 17,
            ACCESS_INDIVIDUAL_SETTING = 18
        }

        public static IEnumerable<Tuple<Guid, string>> GetAllPowerPlans()
        {
            foreach (var guid in GetAll())
            {
                yield return new Tuple<Guid, string>(guid, ReadFriendlyName(guid));
            }
        }

        public static IEnumerable<Guid> GetAll()
        {
            var schemeGuid = Guid.Empty;

            List<Guid> guids = new List<Guid>();

            uint sizeSchemeGuid = (uint)Marshal.SizeOf(typeof(Guid));
            uint schemeIndex = 0;

            while (PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (uint)AccessFlags.ACCESS_SCHEME, schemeIndex, ref schemeGuid, ref sizeSchemeGuid) == 0)
            {
                guids.Add(schemeGuid);
                schemeIndex++;
            }

            return guids;
        }

        public static void SetCurrentPowerPlan(Guid planGuid)
        {
            PowerSetActiveScheme(IntPtr.Zero, ref planGuid);
        }

        public static void SetCurrentPowerPlan(string planName)
        {
            var guidPlans = GetAll();

            foreach (Guid guidPlan in guidPlans)
            {
                if (ReadFriendlyName(guidPlan) == planName)
                {
                    var gp = guidPlan;
                    PowerSetActiveScheme(IntPtr.Zero, ref gp);
                    break;
                }
            }
        }

        private static string ReadFriendlyName(Guid schemeGuid)
        {
            uint sizeName = 1024;
            StringBuilder friendlyName = new StringBuilder((int)sizeName);
            PowerReadFriendlyName(IntPtr.Zero, ref schemeGuid, IntPtr.Zero, IntPtr.Zero, friendlyName, ref sizeName);
            return friendlyName.ToString();
        }

        public static Tuple<Guid, string> GetCurrentPlan()
        {
            IntPtr activeGuidPtr = IntPtr.Zero;

            uint res = PowerGetActiveScheme(IntPtr.Zero, ref activeGuidPtr);
            if (res != 0)
                throw new Win32Exception((int)res);

            try
            {
                Guid activeGuid = (Guid)Marshal.PtrToStructure(activeGuidPtr, typeof(Guid));
                var friendlyName = ReadFriendlyName(activeGuid);

                return new Tuple<Guid, string>(activeGuid, friendlyName);
            }
            finally
            {
                LocalFree(activeGuidPtr);
            }
        }
    }
}
