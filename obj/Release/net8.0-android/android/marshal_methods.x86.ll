; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [135 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [270 x i32] [
	i32 38948123, ; 0: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 0
	i32 39109920, ; 1: Newtonsoft.Json.dll => 0x254c520 => 54
	i32 42244203, ; 2: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 9
	i32 42639949, ; 3: System.Threading.Thread => 0x28aa24d => 124
	i32 67008169, ; 4: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 72070932, ; 5: Microsoft.Maui.Graphics.dll => 0x44bb714 => 53
	i32 83839681, ; 6: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 17
	i32 98325684, ; 7: Microsoft.Extensions.Diagnostics.Abstractions => 0x5dc54b4 => 42
	i32 117431740, ; 8: System.Runtime.InteropServices => 0x6ffddbc => 116
	i32 136584136, ; 9: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 32
	i32 140062828, ; 10: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 25
	i32 165246403, ; 11: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 59
	i32 182336117, ; 12: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 77
	i32 205061960, ; 13: System.ComponentModel => 0xc38ff48 => 92
	i32 221958352, ; 14: Microsoft.Extensions.Diagnostics.dll => 0xd3ad0d0 => 41
	i32 230752869, ; 15: Microsoft.CSharp.dll => 0xdc10265 => 84
	i32 246610117, ; 16: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 114
	i32 291275502, ; 17: Microsoft.Extensions.Http.dll => 0x115c82ee => 43
	i32 296255727, ; 18: LJ.dll => 0x11a880ef => 83
	i32 317674968, ; 19: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 20: Xamarin.AndroidX.Activity.dll => 0x13031348 => 55
	i32 321963286, ; 21: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 8
	i32 342366114, ; 22: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 66
	i32 379916513, ; 23: System.Threading.Thread.dll => 0x16a510e1 => 124
	i32 385762202, ; 24: System.Memory.dll => 0x16fe439a => 103
	i32 395744057, ; 25: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 409257351, ; 26: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 28
	i32 442565967, ; 27: System.Collections => 0x1a61054f => 89
	i32 450948140, ; 28: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 65
	i32 456227837, ; 29: System.Web.HttpUtility.dll => 0x1b317bfd => 126
	i32 459347974, ; 30: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 119
	i32 469710990, ; 31: System.dll => 0x1bff388e => 130
	i32 489220957, ; 32: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 6
	i32 498788369, ; 33: System.ObjectModel => 0x1dbae811 => 109
	i32 513247710, ; 34: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 47
	i32 538707440, ; 35: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 27
	i32 539058512, ; 36: Microsoft.Extensions.Logging => 0x20216150 => 44
	i32 597488923, ; 37: CommunityToolkit.Maui => 0x239cf51b => 35
	i32 627609679, ; 38: Xamarin.AndroidX.CustomView => 0x2568904f => 63
	i32 627931235, ; 39: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 672442732, ; 40: System.Collections.Concurrent => 0x2814a96c => 85
	i32 690569205, ; 41: System.Xml.Linq.dll => 0x29293ff5 => 127
	i32 759454413, ; 42: System.Net.Requests => 0x2d445acd => 107
	i32 775507847, ; 43: System.IO.Compression => 0x2e394f87 => 100
	i32 777317022, ; 44: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 789151979, ; 45: Microsoft.Extensions.Options => 0x2f0980eb => 46
	i32 804715423, ; 46: System.Data.Common => 0x2ff6fb9f => 94
	i32 823281589, ; 47: System.Private.Uri.dll => 0x311247b5 => 110
	i32 830298997, ; 48: System.IO.Compression.Brotli => 0x317d5b75 => 99
	i32 869139383, ; 49: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 10
	i32 880668424, ; 50: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 24
	i32 904024072, ; 51: System.ComponentModel.Primitives.dll => 0x35e25008 => 90
	i32 918734561, ; 52: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 21
	i32 955402788, ; 53: Newtonsoft.Json => 0x38f24a24 => 54
	i32 961460050, ; 54: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 14
	i32 967690846, ; 55: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 66
	i32 975874589, ; 56: System.Xml.XDocument => 0x3a2aaa1d => 129
	i32 990727110, ; 57: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 23
	i32 992768348, ; 58: System.Collections.dll => 0x3b2c715c => 89
	i32 1012816738, ; 59: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 76
	i32 1019214401, ; 60: System.Drawing => 0x3cbffa41 => 98
	i32 1028951442, ; 61: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 40
	i32 1035644815, ; 62: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 56
	i32 1036536393, ; 63: System.Drawing.Primitives.dll => 0x3dc84a49 => 97
	i32 1043950537, ; 64: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 4
	i32 1044663988, ; 65: System.Linq.Expressions.dll => 0x3e444eb4 => 101
	i32 1048992957, ; 66: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0x3e865cbd => 42
	i32 1052210849, ; 67: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 68
	i32 1082857460, ; 68: System.ComponentModel.TypeConverter => 0x408b17f4 => 91
	i32 1084122840, ; 69: Xamarin.Kotlin.StdLib => 0x409e66d8 => 81
	i32 1098259244, ; 70: System => 0x41761b2c => 130
	i32 1108272742, ; 71: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 26
	i32 1117529484, ; 72: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 20
	i32 1118262833, ; 73: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 74: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 75: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 73
	i32 1260983243, ; 76: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1293217323, ; 77: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 64
	i32 1308624726, ; 78: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 11
	i32 1324164729, ; 79: System.Linq => 0x4eed2679 => 102
	i32 1336711579, ; 80: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 31
	i32 1373134921, ; 81: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 82: Xamarin.AndroidX.SavedState => 0x52114ed3 => 76
	i32 1406073936, ; 83: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 60
	i32 1408764838, ; 84: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 118
	i32 1430672901, ; 85: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1461004990, ; 86: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1461234159, ; 87: System.Collections.Immutable.dll => 0x5718a9ef => 86
	i32 1462112819, ; 88: System.IO.Compression.dll => 0x57261233 => 100
	i32 1469204771, ; 89: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 57
	i32 1470490898, ; 90: Microsoft.Extensions.Primitives => 0x57a5e912 => 47
	i32 1479771757, ; 91: System.Collections.Immutable => 0x5833866d => 86
	i32 1480492111, ; 92: System.IO.Compression.Brotli.dll => 0x583e844f => 99
	i32 1505131794, ; 93: Microsoft.Extensions.Http => 0x59b67d12 => 43
	i32 1526286932, ; 94: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 30
	i32 1543031311, ; 95: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 123
	i32 1622152042, ; 96: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 70
	i32 1624863272, ; 97: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 79
	i32 1634654947, ; 98: CommunityToolkit.Maui.Core.dll => 0x616edae3 => 36
	i32 1636350590, ; 99: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 62
	i32 1639515021, ; 100: System.Net.Http.dll => 0x61b9038d => 104
	i32 1639986890, ; 101: System.Text.RegularExpressions => 0x61c036ca => 123
	i32 1657153582, ; 102: System.Runtime => 0x62c6282e => 120
	i32 1658251792, ; 103: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 80
	i32 1677501392, ; 104: System.Net.Primitives.dll => 0x63fca3d0 => 106
	i32 1679769178, ; 105: System.Security.Cryptography => 0x641f3e5a => 121
	i32 1729485958, ; 106: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 58
	i32 1743415430, ; 107: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1763938596, ; 108: System.Diagnostics.TraceSource.dll => 0x69239124 => 96
	i32 1766324549, ; 109: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 77
	i32 1770582343, ; 110: Microsoft.Extensions.Logging.dll => 0x6988f147 => 44
	i32 1780572499, ; 111: Mono.Android.Runtime.dll => 0x6a216153 => 133
	i32 1782862114, ; 112: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 113: Xamarin.AndroidX.Fragment => 0x6a96652d => 65
	i32 1793755602, ; 114: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 115: Xamarin.AndroidX.Loader => 0x6bcd3296 => 70
	i32 1813058853, ; 116: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 81
	i32 1813201214, ; 117: Xamarin.Google.Android.Material => 0x6c13413e => 80
	i32 1818569960, ; 118: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 74
	i32 1824175904, ; 119: System.Text.Encoding.Extensions => 0x6cbab720 => 122
	i32 1824722060, ; 120: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 118
	i32 1828688058, ; 121: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 45
	i32 1853025655, ; 122: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 123: System.Linq.Expressions => 0x6ec71a65 => 101
	i32 1870277092, ; 124: System.Reflection.Primitives => 0x6f7a29e4 => 115
	i32 1875935024, ; 125: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1893218855, ; 126: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 2
	i32 1910275211, ; 127: System.Collections.NonGeneric.dll => 0x71dc7c8b => 87
	i32 1939592360, ; 128: System.Private.Xml.Linq => 0x739bd4a8 => 111
	i32 1953182387, ; 129: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 13
	i32 1968388702, ; 130: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 37
	i32 2003115576, ; 131: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 132: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 68
	i32 2045470958, ; 133: System.Private.Xml => 0x79eb68ee => 112
	i32 2055257422, ; 134: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 67
	i32 2066184531, ; 135: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2070888862, ; 136: System.Diagnostics.TraceSource => 0x7b6f419e => 96
	i32 2079903147, ; 137: System.Runtime.dll => 0x7bf8cdab => 120
	i32 2090596640, ; 138: System.Numerics.Vectors => 0x7c9bf920 => 108
	i32 2127167465, ; 139: System.Console => 0x7ec9ffe9 => 93
	i32 2142473426, ; 140: System.Collections.Specialized => 0x7fb38cd2 => 88
	i32 2159891885, ; 141: Microsoft.Maui => 0x80bd55ad => 51
	i32 2169148018, ; 142: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 143: Microsoft.Extensions.Options.dll => 0x820d22b3 => 46
	i32 2192057212, ; 144: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 45
	i32 2193016926, ; 145: System.ObjectModel.dll => 0x82b6c85e => 109
	i32 2201107256, ; 146: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 82
	i32 2201231467, ; 147: System.Net.Http => 0x8334206b => 104
	i32 2207618523, ; 148: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2261825664, ; 149: LJ => 0x86d0b880 => 83
	i32 2266799131, ; 150: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 38
	i32 2279755925, ; 151: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 75
	i32 2298471582, ; 152: System.Net.Mail => 0x88ffe49e => 105
	i32 2303942373, ; 153: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 154: System.Private.CoreLib.dll => 0x896b7878 => 131
	i32 2353062107, ; 155: System.Net.Primitives => 0x8c40e0db => 106
	i32 2366048013, ; 156: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 12
	i32 2368005991, ; 157: System.Xml.ReaderWriter.dll => 0x8d24e767 => 128
	i32 2371007202, ; 158: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 37
	i32 2395872292, ; 159: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2401565422, ; 160: System.Web.HttpUtility => 0x8f24faee => 126
	i32 2427813419, ; 161: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 162: System.Console.dll => 0x912896e5 => 93
	i32 2475788418, ; 163: Java.Interop.dll => 0x93918882 => 132
	i32 2480646305, ; 164: Microsoft.Maui.Controls => 0x93dba8a1 => 49
	i32 2503351294, ; 165: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 16
	i32 2538310050, ; 166: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 114
	i32 2550873716, ; 167: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2562349572, ; 168: Microsoft.CSharp => 0x98ba5a04 => 84
	i32 2576534780, ; 169: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 15
	i32 2585220780, ; 170: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 122
	i32 2593496499, ; 171: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 172: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 82
	i32 2617129537, ; 173: System.Private.Xml.dll => 0x9bfe3a41 => 112
	i32 2620871830, ; 174: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 62
	i32 2626831493, ; 175: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2664396074, ; 176: System.Xml.XDocument.dll => 0x9ecf752a => 129
	i32 2665622720, ; 177: System.Drawing.Primitives => 0x9ee22cc0 => 97
	i32 2676780864, ; 178: System.Data.Common.dll => 0x9f8c6f40 => 94
	i32 2724373263, ; 179: System.Runtime.Numerics.dll => 0xa262a30f => 117
	i32 2732626843, ; 180: Xamarin.AndroidX.Activity => 0xa2e0939b => 55
	i32 2737747696, ; 181: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 57
	i32 2740698338, ; 182: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 1
	i32 2752995522, ; 183: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 184: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 50
	i32 2764765095, ; 185: Microsoft.Maui.dll => 0xa4caf7a7 => 51
	i32 2778768386, ; 186: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 78
	i32 2785988530, ; 187: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 188: Microsoft.Maui.Graphics => 0xa7008e0b => 53
	i32 2810250172, ; 189: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 60
	i32 2853208004, ; 190: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 78
	i32 2861189240, ; 191: Microsoft.Maui.Essentials => 0xaa8a4878 => 52
	i32 2868488919, ; 192: CommunityToolkit.Maui.Core => 0xaaf9aad7 => 36
	i32 2909740682, ; 193: System.Private.CoreLib => 0xad6f1e8a => 131
	i32 2916838712, ; 194: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 79
	i32 2919462931, ; 195: System.Numerics.Vectors.dll => 0xae037813 => 108
	i32 2959614098, ; 196: System.ComponentModel.dll => 0xb0682092 => 92
	i32 2978675010, ; 197: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 64
	i32 3020703001, ; 198: Microsoft.Extensions.Diagnostics => 0xb40c4519 => 41
	i32 3038032645, ; 199: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3053864966, ; 200: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 7
	i32 3057625584, ; 201: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 71
	i32 3059408633, ; 202: Mono.Android.Runtime => 0xb65adef9 => 133
	i32 3059793426, ; 203: System.ComponentModel.Primitives => 0xb660be12 => 90
	i32 3159123045, ; 204: System.Reflection.Primitives.dll => 0xbc4c6465 => 115
	i32 3178803400, ; 205: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 72
	i32 3220365878, ; 206: System.Threading => 0xbff2e236 => 125
	i32 3258312781, ; 207: Xamarin.AndroidX.CardView => 0xc235e84d => 58
	i32 3305363605, ; 208: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 209: System.Net.Requests.dll => 0xc5b097e4 => 107
	i32 3317135071, ; 210: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 63
	i32 3346324047, ; 211: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 73
	i32 3357674450, ; 212: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3362522851, ; 213: Xamarin.AndroidX.Core => 0xc86c06e3 => 61
	i32 3366347497, ; 214: Java.Interop => 0xc8a662e9 => 132
	i32 3374999561, ; 215: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 75
	i32 3381016424, ; 216: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3428513518, ; 217: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 39
	i32 3452344032, ; 218: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 48
	i32 3458724246, ; 219: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 22
	i32 3471940407, ; 220: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 91
	i32 3476120550, ; 221: Mono.Android => 0xcf3163e6 => 134
	i32 3484440000, ; 222: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3509114376, ; 223: System.Xml.Linq => 0xd128d608 => 127
	i32 3580758918, ; 224: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3592228221, ; 225: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 33
	i32 3608519521, ; 226: System.Linq.dll => 0xd715a361 => 102
	i32 3641597786, ; 227: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 67
	i32 3643446276, ; 228: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 229: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 72
	i32 3657292374, ; 230: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 38
	i32 3672681054, ; 231: Mono.Android.dll => 0xdae8aa5e => 134
	i32 3724971120, ; 232: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 71
	i32 3748608112, ; 233: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 95
	i32 3751619990, ; 234: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 3
	i32 3786282454, ; 235: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 59
	i32 3792276235, ; 236: System.Collections.NonGeneric => 0xe2098b0b => 87
	i32 3800979733, ; 237: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 48
	i32 3802395368, ; 238: System.Collections.Specialized.dll => 0xe2a3f2e8 => 88
	i32 3817368567, ; 239: CommunityToolkit.Maui.dll => 0xe3886bf7 => 35
	i32 3823082795, ; 240: System.Security.Cryptography.dll => 0xe3df9d2b => 121
	i32 3841636137, ; 241: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 40
	i32 3844307129, ; 242: System.Net.Mail.dll => 0xe52378b9 => 105
	i32 3849253459, ; 243: System.Runtime.InteropServices.dll => 0xe56ef253 => 116
	i32 3896106733, ; 244: System.Collections.Concurrent.dll => 0xe839deed => 85
	i32 3896760992, ; 245: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 61
	i32 3920221145, ; 246: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 19
	i32 3928044579, ; 247: System.Xml.ReaderWriter => 0xea213423 => 128
	i32 3931092270, ; 248: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 74
	i32 3955647286, ; 249: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 56
	i32 4025784931, ; 250: System.Memory => 0xeff49a63 => 103
	i32 4046471985, ; 251: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 50
	i32 4054681211, ; 252: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 113
	i32 4068434129, ; 253: System.Private.Xml.Linq.dll => 0xf27f60d1 => 111
	i32 4073602200, ; 254: System.Threading.dll => 0xf2ce3c98 => 125
	i32 4091086043, ; 255: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 5
	i32 4094352644, ; 256: Microsoft.Maui.Essentials.dll => 0xf40add04 => 52
	i32 4099507663, ; 257: System.Drawing.dll => 0xf45985cf => 98
	i32 4100113165, ; 258: System.Private.Uri => 0xf462c30d => 110
	i32 4103439459, ; 259: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 29
	i32 4126470640, ; 260: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 39
	i32 4147896353, ; 261: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 113
	i32 4150914736, ; 262: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4181436372, ; 263: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 119
	i32 4182413190, ; 264: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 69
	i32 4213026141, ; 265: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 95
	i32 4249188766, ; 266: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 18
	i32 4271975918, ; 267: Microsoft.Maui.Controls.dll => 0xfea12dee => 49
	i32 4274976490, ; 268: System.Runtime.Numerics => 0xfecef6ea => 117
	i32 4292120959 ; 269: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 69
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [270 x i32] [
	i32 0, ; 0
	i32 54, ; 1
	i32 9, ; 2
	i32 124, ; 3
	i32 33, ; 4
	i32 53, ; 5
	i32 17, ; 6
	i32 42, ; 7
	i32 116, ; 8
	i32 32, ; 9
	i32 25, ; 10
	i32 59, ; 11
	i32 77, ; 12
	i32 92, ; 13
	i32 41, ; 14
	i32 84, ; 15
	i32 114, ; 16
	i32 43, ; 17
	i32 83, ; 18
	i32 30, ; 19
	i32 55, ; 20
	i32 8, ; 21
	i32 66, ; 22
	i32 124, ; 23
	i32 103, ; 24
	i32 34, ; 25
	i32 28, ; 26
	i32 89, ; 27
	i32 65, ; 28
	i32 126, ; 29
	i32 119, ; 30
	i32 130, ; 31
	i32 6, ; 32
	i32 109, ; 33
	i32 47, ; 34
	i32 27, ; 35
	i32 44, ; 36
	i32 35, ; 37
	i32 63, ; 38
	i32 19, ; 39
	i32 85, ; 40
	i32 127, ; 41
	i32 107, ; 42
	i32 100, ; 43
	i32 25, ; 44
	i32 46, ; 45
	i32 94, ; 46
	i32 110, ; 47
	i32 99, ; 48
	i32 10, ; 49
	i32 24, ; 50
	i32 90, ; 51
	i32 21, ; 52
	i32 54, ; 53
	i32 14, ; 54
	i32 66, ; 55
	i32 129, ; 56
	i32 23, ; 57
	i32 89, ; 58
	i32 76, ; 59
	i32 98, ; 60
	i32 40, ; 61
	i32 56, ; 62
	i32 97, ; 63
	i32 4, ; 64
	i32 101, ; 65
	i32 42, ; 66
	i32 68, ; 67
	i32 91, ; 68
	i32 81, ; 69
	i32 130, ; 70
	i32 26, ; 71
	i32 20, ; 72
	i32 16, ; 73
	i32 22, ; 74
	i32 73, ; 75
	i32 2, ; 76
	i32 64, ; 77
	i32 11, ; 78
	i32 102, ; 79
	i32 31, ; 80
	i32 32, ; 81
	i32 76, ; 82
	i32 60, ; 83
	i32 118, ; 84
	i32 0, ; 85
	i32 6, ; 86
	i32 86, ; 87
	i32 100, ; 88
	i32 57, ; 89
	i32 47, ; 90
	i32 86, ; 91
	i32 99, ; 92
	i32 43, ; 93
	i32 30, ; 94
	i32 123, ; 95
	i32 70, ; 96
	i32 79, ; 97
	i32 36, ; 98
	i32 62, ; 99
	i32 104, ; 100
	i32 123, ; 101
	i32 120, ; 102
	i32 80, ; 103
	i32 106, ; 104
	i32 121, ; 105
	i32 58, ; 106
	i32 1, ; 107
	i32 96, ; 108
	i32 77, ; 109
	i32 44, ; 110
	i32 133, ; 111
	i32 17, ; 112
	i32 65, ; 113
	i32 9, ; 114
	i32 70, ; 115
	i32 81, ; 116
	i32 80, ; 117
	i32 74, ; 118
	i32 122, ; 119
	i32 118, ; 120
	i32 45, ; 121
	i32 26, ; 122
	i32 101, ; 123
	i32 115, ; 124
	i32 8, ; 125
	i32 2, ; 126
	i32 87, ; 127
	i32 111, ; 128
	i32 13, ; 129
	i32 37, ; 130
	i32 5, ; 131
	i32 68, ; 132
	i32 112, ; 133
	i32 67, ; 134
	i32 4, ; 135
	i32 96, ; 136
	i32 120, ; 137
	i32 108, ; 138
	i32 93, ; 139
	i32 88, ; 140
	i32 51, ; 141
	i32 12, ; 142
	i32 46, ; 143
	i32 45, ; 144
	i32 109, ; 145
	i32 82, ; 146
	i32 104, ; 147
	i32 14, ; 148
	i32 83, ; 149
	i32 38, ; 150
	i32 75, ; 151
	i32 105, ; 152
	i32 18, ; 153
	i32 131, ; 154
	i32 106, ; 155
	i32 12, ; 156
	i32 128, ; 157
	i32 37, ; 158
	i32 13, ; 159
	i32 126, ; 160
	i32 10, ; 161
	i32 93, ; 162
	i32 132, ; 163
	i32 49, ; 164
	i32 16, ; 165
	i32 114, ; 166
	i32 11, ; 167
	i32 84, ; 168
	i32 15, ; 169
	i32 122, ; 170
	i32 20, ; 171
	i32 82, ; 172
	i32 112, ; 173
	i32 62, ; 174
	i32 15, ; 175
	i32 129, ; 176
	i32 97, ; 177
	i32 94, ; 178
	i32 117, ; 179
	i32 55, ; 180
	i32 57, ; 181
	i32 1, ; 182
	i32 21, ; 183
	i32 50, ; 184
	i32 51, ; 185
	i32 78, ; 186
	i32 27, ; 187
	i32 53, ; 188
	i32 60, ; 189
	i32 78, ; 190
	i32 52, ; 191
	i32 36, ; 192
	i32 131, ; 193
	i32 79, ; 194
	i32 108, ; 195
	i32 92, ; 196
	i32 64, ; 197
	i32 41, ; 198
	i32 34, ; 199
	i32 7, ; 200
	i32 71, ; 201
	i32 133, ; 202
	i32 90, ; 203
	i32 115, ; 204
	i32 72, ; 205
	i32 125, ; 206
	i32 58, ; 207
	i32 7, ; 208
	i32 107, ; 209
	i32 63, ; 210
	i32 73, ; 211
	i32 24, ; 212
	i32 61, ; 213
	i32 132, ; 214
	i32 75, ; 215
	i32 3, ; 216
	i32 39, ; 217
	i32 48, ; 218
	i32 22, ; 219
	i32 91, ; 220
	i32 134, ; 221
	i32 23, ; 222
	i32 127, ; 223
	i32 31, ; 224
	i32 33, ; 225
	i32 102, ; 226
	i32 67, ; 227
	i32 28, ; 228
	i32 72, ; 229
	i32 38, ; 230
	i32 134, ; 231
	i32 71, ; 232
	i32 95, ; 233
	i32 3, ; 234
	i32 59, ; 235
	i32 87, ; 236
	i32 48, ; 237
	i32 88, ; 238
	i32 35, ; 239
	i32 121, ; 240
	i32 40, ; 241
	i32 105, ; 242
	i32 116, ; 243
	i32 85, ; 244
	i32 61, ; 245
	i32 19, ; 246
	i32 128, ; 247
	i32 74, ; 248
	i32 56, ; 249
	i32 103, ; 250
	i32 50, ; 251
	i32 113, ; 252
	i32 111, ; 253
	i32 125, ; 254
	i32 5, ; 255
	i32 52, ; 256
	i32 98, ; 257
	i32 110, ; 258
	i32 29, ; 259
	i32 39, ; 260
	i32 113, ; 261
	i32 29, ; 262
	i32 119, ; 263
	i32 69, ; 264
	i32 95, ; 265
	i32 18, ; 266
	i32 49, ; 267
	i32 117, ; 268
	i32 69 ; 269
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ f1b7113872c8db3dfee70d11925e81bb752dc8d0"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
