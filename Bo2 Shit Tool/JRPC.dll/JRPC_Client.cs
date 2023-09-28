using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using XDevkit;

namespace JRPC_Client
{
	
	public static class JRPC
	{
		
		public static string ToHexString(this string String)
		{
			string text = "";
			for (int i = 0; i < String.Length; i++)
			{
				text += ((byte)String[i]).ToString("X2");
			}
			return text;
		}

		
		public static void Push(this byte[] InArray, out byte[] OutArray, byte Value)
		{
			OutArray = new byte[InArray.Length + 1];
			InArray.CopyTo(OutArray, 0);
			OutArray[InArray.Length] = Value;
		}

		
		public static byte[] ToByteArray(this string String)
		{
			byte[] array = new byte[String.Length + 1];
			for (int i = 0; i < String.Length; i++)
			{
				array[i] = (byte)String[i];
			}
			return array;
		}

		
		public static int find(this string String, string _Ptr)
		{
			if (_Ptr.Length == 0 || String.Length == 0)
			{
				return -1;
			}
			for (int i = 0; i < String.Length; i++)
			{
				if (String[i] == _Ptr[0])
				{
					bool flag = true;
					for (int j = 0; j < _Ptr.Length; j++)
					{
						if (String[i + j] != _Ptr[j])
						{
							flag = false;
						}
					}
					if (flag)
					{
						return i;
					}
				}
			}
			return -1;
		}

		
		public static bool Connect(this IXboxConsole console, out IXboxConsole Console, string XboxNameOrIP = "default")
		{
			if (XboxNameOrIP == "default")
			{
				XboxNameOrIP = ((IXboxManager)new XboxManagerClass()).DefaultConsole;
			}
			IXboxConsole xboxConsole = ((IXboxManager)new XboxManagerClass()).OpenConsole(XboxNameOrIP);
			int num = 0;
			bool flag = false;
			while (!flag)
			{
				try
				{
					JRPC.connectionId = xboxConsole.OpenConnection(null);
					flag = true;
				}
				catch (COMException ex)
				{
					if (ex.ErrorCode != JRPC.UIntToInt(2195325184U))
					{
						Console = xboxConsole;
						return false;
					}
					if (num >= 3)
					{
						Console = xboxConsole;
						return false;
					}
					num++;
					Thread.Sleep(100);
				}
			}
			Console = xboxConsole;
			return true;
		}

		
		public static string XboxIP(this IXboxConsole console)
		{
			byte[] bytes = BitConverter.GetBytes(console.IPAddress);
			Array.Reverse(bytes);
			return new IPAddress(bytes).ToString();
		}

		
		internal static ulong ConvertToUInt64(object o)
		{
			if (o is bool)
			{
				if ((bool)o)
				{
					return 1UL;
				}
				return 0UL;
			}
			else
			{
				if (o is byte)
				{
					return (ulong)((byte)o);
				}
				if (o is short)
				{
					return (ulong)((long)((short)o));
				}
				if (o is int)
				{
					return (ulong)((long)((int)o));
				}
				if (o is long)
				{
					return (ulong)((long)o);
				}
				if (o is ushort)
				{
					return (ulong)((ushort)o);
				}
				if (o is uint)
				{
					return (ulong)((uint)o);
				}
				if (o is ulong)
				{
					return (ulong)o;
				}
				if (o is float)
				{
					return (ulong)BitConverter.DoubleToInt64Bits((double)((float)o));
				}
				if (o is double)
				{
					return (ulong)BitConverter.DoubleToInt64Bits((double)o);
				}
				return 0UL;
			}
		}

		
		internal static bool IsValidStructType(Type t)
		{
			return !t.IsPrimitive && t.IsValueType;
		}

		
		internal static bool IsValidReturnType(Type t)
		{
			return JRPC.ValidReturnTypes.Contains(t);
		}

		
		private static void ReverseBytes(byte[] buffer, int groupSize)
		{
			if (buffer.Length % groupSize != 0)
			{
				throw new ArgumentException("Group size must be a multiple of the buffer length", "groupSize");
			}
			for (int i = 0; i < buffer.Length; i += groupSize)
			{
				int j = i;
				int num = i + groupSize - 1;
				while (j < num)
				{
					byte b = buffer[j];
					buffer[j] = buffer[num];
					buffer[num] = b;
					j++;
					num--;
				}
			}
		}

		
		public static byte[] GetMemory(this IXboxConsole console, uint Address, uint Length)
		{
			uint num = 0U;
			byte[] array = new byte[Length];
			console.DebugTarget.GetMemory(Address, Length, array, out num);
			console.DebugTarget.InvalidateMemoryCache(true, Address, Length);
			return array;
		}

		
		public static sbyte ReadSByte(this IXboxConsole console, uint Address)
		{
			return (sbyte)console.GetMemory(Address, 1U)[0];
		}

		
		public static byte ReadByte(this IXboxConsole console, uint Address)
		{
			return console.GetMemory(Address, 1U)[0];
		}

		
		public static bool ReadBool(this IXboxConsole console, uint Address)
		{
			return console.GetMemory(Address, 1U)[0] != 0;
		}

		
		public static float ReadFloat(this IXboxConsole console, uint Address)
		{
			byte[] memory = console.GetMemory(Address, 4U);
			JRPC.ReverseBytes(memory, 4);
			return BitConverter.ToSingle(memory, 0);
		}

		
		public static float[] ReadFloat(this IXboxConsole console, uint Address, uint ArraySize)
		{
			float[] array = new float[ArraySize];
			byte[] memory = console.GetMemory(Address, ArraySize * 4U);
			JRPC.ReverseBytes(memory, 4);
			int num = 0;
			while ((long)num < (long)((ulong)ArraySize))
			{
				array[num] = BitConverter.ToSingle(memory, num * 4);
				num++;
			}
			return array;
		}

		
		public static short ReadInt16(this IXboxConsole console, uint Address)
		{
			byte[] memory = console.GetMemory(Address, 2U);
			JRPC.ReverseBytes(memory, 2);
			return BitConverter.ToInt16(memory, 0);
		}

		
		public static short[] ReadInt16(this IXboxConsole console, uint Address, uint ArraySize)
		{
			short[] array = new short[ArraySize];
			byte[] memory = console.GetMemory(Address, ArraySize * 2U);
			JRPC.ReverseBytes(memory, 2);
			int num = 0;
			while ((long)num < (long)((ulong)ArraySize))
			{
				array[num] = BitConverter.ToInt16(memory, num * 2);
				num++;
			}
			return array;
		}

		
		public static ushort ReadUInt16(this IXboxConsole console, uint Address)
		{
			byte[] memory = console.GetMemory(Address, 2U);
			JRPC.ReverseBytes(memory, 2);
			return BitConverter.ToUInt16(memory, 0);
		}

		
		public static ushort[] ReadUInt16(this IXboxConsole console, uint Address, uint ArraySize)
		{
			ushort[] array = new ushort[ArraySize];
			byte[] memory = console.GetMemory(Address, ArraySize * 2U);
			JRPC.ReverseBytes(memory, 2);
			int num = 0;
			while ((long)num < (long)((ulong)ArraySize))
			{
				array[num] = BitConverter.ToUInt16(memory, num * 2);
				num++;
			}
			return array;
		}

		
		public static int ReadInt32(this IXboxConsole console, uint Address)
		{
			byte[] memory = console.GetMemory(Address, 4U);
			JRPC.ReverseBytes(memory, 4);
			return BitConverter.ToInt32(memory, 0);
		}

		
		public static int[] ReadInt32(this IXboxConsole console, uint Address, uint ArraySize)
		{
			int[] array = new int[ArraySize];
			byte[] memory = console.GetMemory(Address, ArraySize * 4U);
			JRPC.ReverseBytes(memory, 4);
			int num = 0;
			while ((long)num < (long)((ulong)ArraySize))
			{
				array[num] = BitConverter.ToInt32(memory, num * 4);
				num++;
			}
			return array;
		}

		
		public static uint ReadUInt32(this IXboxConsole console, uint Address)
		{
			byte[] memory = console.GetMemory(Address, 4U);
			JRPC.ReverseBytes(memory, 4);
			return BitConverter.ToUInt32(memory, 0);
		}

		
		public static uint[] ReadUInt32(this IXboxConsole console, uint Address, uint ArraySize)
		{
			uint[] array = new uint[ArraySize];
			byte[] memory = console.GetMemory(Address, ArraySize * 4U);
			JRPC.ReverseBytes(memory, 4);
			int num = 0;
			while ((long)num < (long)((ulong)ArraySize))
			{
				array[num] = BitConverter.ToUInt32(memory, num * 4);
				num++;
			}
			return array;
		}

		
		public static long ReadInt64(this IXboxConsole console, uint Address)
		{
			byte[] memory = console.GetMemory(Address, 8U);
			JRPC.ReverseBytes(memory, 8);
			return BitConverter.ToInt64(memory, 0);
		}

		
		public static long[] ReadInt64(this IXboxConsole console, uint Address, uint ArraySize)
		{
			long[] array = new long[ArraySize];
			byte[] memory = console.GetMemory(Address, ArraySize * 8U);
			JRPC.ReverseBytes(memory, 8);
			int num = 0;
			while ((long)num < (long)((ulong)ArraySize))
			{
				array[num] = (long)((ulong)BitConverter.ToUInt32(memory, num * 8));
				num++;
			}
			return array;
		}

		
		public static ulong ReadUInt64(this IXboxConsole console, uint Address)
		{
			byte[] memory = console.GetMemory(Address, 8U);
			JRPC.ReverseBytes(memory, 8);
			return BitConverter.ToUInt64(memory, 0);
		}

		
		public static ulong[] ReadUInt64(this IXboxConsole console, uint Address, uint ArraySize)
		{
			ulong[] array = new ulong[ArraySize];
			byte[] memory = console.GetMemory(Address, ArraySize * 8U);
			JRPC.ReverseBytes(memory, 8);
			int num = 0;
			while ((long)num < (long)((ulong)ArraySize))
			{
				array[num] = (ulong)BitConverter.ToUInt32(memory, num * 8);
				num++;
			}
			return array;
		}

		
		public static string ReadString(this IXboxConsole console, uint Address, uint size)
		{
			return Encoding.UTF8.GetString(console.GetMemory(Address, size));
		}

		
		public static void SetMemory(this IXboxConsole console, uint Address, byte[] Data)
		{
			uint num;
			console.DebugTarget.SetMemory(Address, (uint)Data.Length, Data, out num);
		}

		
		public static void WriteSByte(this IXboxConsole console, uint Address, sbyte Value)
		{
			console.SetMemory(Address, new byte[]
			{
				BitConverter.GetBytes((short)Value)[0]
			});
		}

		
		public static void WriteSByte(this IXboxConsole console, uint Address, sbyte[] Value)
		{
			byte[] array = new byte[0];
			foreach (byte value in Value)
			{
				array.Push(out array, value);
			}
			console.SetMemory(Address, array);
		}

		
		public static void WriteByte(this IXboxConsole console, uint Address, byte Value)
		{
			console.SetMemory(Address, new byte[]
			{
				Value
			});
		}

		
		public static void WriteByte(this IXboxConsole console, uint Address, byte[] Value)
		{
			console.SetMemory(Address, Value);
		}

		
		public static void WriteBool(this IXboxConsole console, uint Address, bool Value)
		{
			console.SetMemory(Address, new byte[]
			{
				Value ? 1 : 0
			});
		}

		
		public static void WriteBool(this IXboxConsole console, uint Address, bool[] Value)
		{
			byte[] array = new byte[0];
			for (int i = 0; i < Value.Length; i++)
			{
				array.Push(out array, Value[i] ? 1 : 0);
			}
			console.SetMemory(Address, array);
		}

		
		public static void WriteFloat(this IXboxConsole console, uint Address, float Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			Array.Reverse(bytes);
			console.SetMemory(Address, bytes);
		}

		
		public static void WriteFloat(this IXboxConsole console, uint Address, float[] Value)
		{
			byte[] array = new byte[Value.Length * 4];
			for (int i = 0; i < Value.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(Value[i]);
				JRPC.ReverseBytes(array, 4);
				bytes.CopyTo(array, i * 4);
			}
			console.SetMemory(Address, array);
		}

		
		public static void WriteInt16(this IXboxConsole console, uint Address, short Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			JRPC.ReverseBytes(bytes, 2);
			console.SetMemory(Address, bytes);
		}

		
		public static void WriteInt16(this IXboxConsole console, uint Address, short[] Value)
		{
			byte[] array = new byte[Value.Length * 2];
			for (int i = 0; i < Value.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(Value[i]);
				JRPC.ReverseBytes(array, 2);
				bytes.CopyTo(array, i * 2);
			}
			console.SetMemory(Address, array);
		}

		
		public static void WriteUInt16(this IXboxConsole console, uint Address, ushort Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			JRPC.ReverseBytes(bytes, 2);
			console.SetMemory(Address, bytes);
		}

		
		public static void WriteUInt16(this IXboxConsole console, uint Address, ushort[] Value)
		{
			byte[] array = new byte[Value.Length * 2];
			for (int i = 0; i < Value.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(Value[i]);
				JRPC.ReverseBytes(array, 2);
				bytes.CopyTo(array, i * 2);
			}
			console.SetMemory(Address, array);
		}

		
		public static void WriteInt32(this IXboxConsole console, uint Address, int Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			JRPC.ReverseBytes(bytes, 4);
			console.SetMemory(Address, bytes);
		}

		
		public static void WriteInt32(this IXboxConsole console, uint Address, int[] Value)
		{
			byte[] array = new byte[Value.Length * 4];
			for (int i = 0; i < Value.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(Value[i]);
				JRPC.ReverseBytes(array, 4);
				bytes.CopyTo(array, i * 4);
			}
			console.SetMemory(Address, array);
		}

		
		public static void WriteUInt32(this IXboxConsole console, uint Address, uint Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			JRPC.ReverseBytes(bytes, 4);
			console.SetMemory(Address, bytes);
		}

		
		public static void WriteUInt32(this IXboxConsole console, uint Address, uint[] Value)
		{
			byte[] array = new byte[Value.Length * 4];
			for (int i = 0; i < Value.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(Value[i]);
				JRPC.ReverseBytes(array, 4);
				bytes.CopyTo(array, i * 4);
			}
			console.SetMemory(Address, array);
		}

		
		public static void WriteInt64(this IXboxConsole console, uint Address, long Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			JRPC.ReverseBytes(bytes, 8);
			console.SetMemory(Address, bytes);
		}

		
		public static void WriteInt64(this IXboxConsole console, uint Address, long[] Value)
		{
			byte[] array = new byte[Value.Length * 8];
			for (int i = 0; i < Value.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(Value[i]);
				JRPC.ReverseBytes(array, 8);
				bytes.CopyTo(array, i * 8);
			}
			console.SetMemory(Address, array);
		}

		
		public static void WriteUInt64(this IXboxConsole console, uint Address, ulong Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			JRPC.ReverseBytes(bytes, 8);
			console.SetMemory(Address, bytes);
		}

		
		public static void WriteUInt64(this IXboxConsole console, uint Address, ulong[] Value)
		{
			byte[] array = new byte[Value.Length * 8];
			for (int i = 0; i < Value.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(Value[i]);
				JRPC.ReverseBytes(array, 8);
				bytes.CopyTo(array, i * 8);
			}
			console.SetMemory(Address, array);
		}

		
		public static void WriteString(this IXboxConsole console, uint Address, string String)
		{
			byte[] array = new byte[0];
			foreach (byte value in String)
			{
				array.Push(out array, value);
			}
			array.Push(out array, 0);
			console.SetMemory(Address, array);
		}

		
		public static uint ResolveFunction(this IXboxConsole console, string ModuleName, uint Ordinal)
		{
			string command = string.Concat(new object[]
			{
				"consolefeatures ver=",
				JRPC.JRPCVersion,
				" type=9 params=\"A\\0\\A\\2\\",
				JRPC.String,
				"/",
				ModuleName.Length,
				"\\",
				ModuleName.ToHexString(),
				"\\",
				JRPC.Int,
				"\\",
				Ordinal,
				"\\\""
			});
			string text = JRPC.SendCommand(console, command);
			return uint.Parse(text.Substring(text.find(" ") + 1), NumberStyles.HexNumber);
		}

		
		public static string GetCPUKey(this IXboxConsole console)
		{
			string command = "consolefeatures ver=" + JRPC.JRPCVersion + " type=10 params=\"A\\0\\A\\0\\\"";
			string text = JRPC.SendCommand(console, command);
			return text.Substring(text.find(" ") + 1);
		}

		
		public static void ShutDownConsole(this IXboxConsole console)
		{
			try
			{
				string command = "consolefeatures ver=" + JRPC.JRPCVersion + " type=11 params=\"A\\0\\A\\0\\\"";
				JRPC.SendCommand(console, command);
			}
			catch
			{
			}
		}

		
		public static byte[] WCHAR(string String)
		{
			byte[] array = new byte[String.Length * 2 + 2];
			int num = 1;
			foreach (byte b in String)
			{
				array[num] = b;
				num += 2;
			}
			return array;
		}

		
		public static byte[] ToWCHAR(this string String)
		{
			byte[] array = new byte[String.Length * 2 + 2];
			int num = 1;
			foreach (byte b in String)
			{
				array[num] = b;
				num += 2;
			}
			return array;
		}

		
		public static uint GetKernalVersion(this IXboxConsole console)
		{
			string command = "consolefeatures ver=" + JRPC.JRPCVersion + " type=13 params=\"A\\0\\A\\0\\\"";
			string text = JRPC.SendCommand(console, command);
			return uint.Parse(text.Substring(text.find(" ") + 1));
		}

		
		public static void SetLeds(this IXboxConsole console, JRPC.LEDState Top_Left, JRPC.LEDState Top_Right, JRPC.LEDState Bottom_Left, JRPC.LEDState Bottom_Right)
		{
			string command = string.Concat(new object[]
			{
				"consolefeatures ver=",
				JRPC.JRPCVersion,
				" type=14 params=\"A\\0\\A\\4\\",
				JRPC.Int,
				"\\",
				(uint)Top_Left,
				"\\",
				JRPC.Int,
				"\\",
				(uint)Top_Right,
				"\\",
				JRPC.Int,
				"\\",
				(uint)Bottom_Left,
				"\\",
				JRPC.Int,
				"\\",
				(uint)Bottom_Right,
				"\\\""
			});
			JRPC.SendCommand(console, command);
		}

		
		public static uint GetTemperature(this IXboxConsole console, JRPC.TemperatureType TemperatureType)
		{
			string command = string.Concat(new object[]
			{
				"consolefeatures ver=",
				JRPC.JRPCVersion,
				" type=15 params=\"A\\0\\A\\1\\",
				JRPC.Int,
				"\\",
				(int)TemperatureType,
				"\\\""
			});
			string text = JRPC.SendCommand(console, command);
			return uint.Parse(text.Substring(text.find(" ") + 1), NumberStyles.HexNumber);
		}

		
		public static void XNotify(this IXboxConsole console, string Text)
		{
			console.XNotify(Text, 34U);
		}

		
		public static void XNotify(this IXboxConsole console, string Text, uint Type)
		{
			string command = string.Concat(new object[]
			{
				"consolefeatures ver=",
				JRPC.JRPCVersion,
				" type=12 params=\"A\\0\\A\\2\\",
				JRPC.String,
				"/",
				Text.Length,
				"\\",
				Text.ToHexString(),
				"\\",
				JRPC.Int,
				"\\",
				Type,
				"\\\""
			});
			JRPC.SendCommand(console, command);
		}

		
		public static uint XamGetCurrentTitleId(this IXboxConsole console)
		{
			string command = "consolefeatures ver=" + JRPC.JRPCVersion + " type=16 params=\"A\\0\\A\\0\\\"";
			string text = JRPC.SendCommand(console, command);
			return uint.Parse(text.Substring(text.find(" ") + 1), NumberStyles.HexNumber);
		}

		
		public static string ConsoleType(this IXboxConsole console)
		{
			string command = "consolefeatures ver=" + JRPC.JRPCVersion + " type=17 params=\"A\\0\\A\\0\\\"";
			string text = JRPC.SendCommand(console, command);
			return text.Substring(text.find(" ") + 1);
		}

		
		public static void constantMemorySet(this IXboxConsole console, uint Address, uint Value)
		{
			JRPC.constantMemorySetting(console, Address, Value, false, 0U, false, 0U);
		}

		
		public static void constantMemorySet(this IXboxConsole console, uint Address, uint Value, uint TitleID)
		{
			JRPC.constantMemorySetting(console, Address, Value, false, 0U, true, TitleID);
		}

		
		public static void constantMemorySet(this IXboxConsole console, uint Address, uint Value, uint IfValue, uint TitleID)
		{
			JRPC.constantMemorySetting(console, Address, Value, true, IfValue, true, TitleID);
		}

		
		public static void constantMemorySetting(IXboxConsole console, uint Address, uint Value, bool useIfValue, uint IfValue, bool usetitleID, uint TitleID)
		{
			string command = string.Concat(new object[]
			{
				"consolefeatures ver=",
				JRPC.JRPCVersion,
				" type=18 params=\"A\\",
				Address.ToString("X"),
				"\\A\\5\\",
				JRPC.Int,
				"\\",
				JRPC.UIntToInt(Value),
				"\\",
				JRPC.Int,
				"\\",
				useIfValue ? 1 : 0,
				"\\",
				JRPC.Int,
				"\\",
				IfValue,
				"\\",
				JRPC.Int,
				"\\",
				usetitleID ? 1 : 0,
				"\\",
				JRPC.Int,
				"\\",
				JRPC.UIntToInt(TitleID),
				"\\\""
			});
			JRPC.SendCommand(console, command);
		}

		
		private static uint TypeToType<T>(bool Array) where T : struct
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle == typeof(int) || typeFromHandle == typeof(uint) || typeFromHandle == typeof(short) || typeFromHandle == typeof(ushort))
			{
				if (Array)
				{
					return JRPC.IntArray;
				}
				return JRPC.Int;
			}
			else
			{
				if (typeFromHandle == typeof(string) || typeFromHandle == typeof(char[]))
				{
					return JRPC.String;
				}
				if (typeFromHandle == typeof(float) || typeFromHandle == typeof(double))
				{
					if (Array)
					{
						return JRPC.FloatArray;
					}
					return JRPC.Float;
				}
				else if (typeFromHandle == typeof(byte) || typeFromHandle == typeof(char))
				{
					if (Array)
					{
						return JRPC.ByteArray;
					}
					return JRPC.Byte;
				}
				else
				{
					if (typeFromHandle != typeof(ulong) && typeFromHandle != typeof(long))
					{
						return JRPC.Uint64;
					}
					if (Array)
					{
						return JRPC.Uint64Array;
					}
					return JRPC.Uint64;
				}
			}
		}

		
		public static T Call<T>(this IXboxConsole console, uint Address, params object[] Arguments) where T : struct
		{
			return (T)((object)JRPC.CallArgs(console, true, JRPC.TypeToType<T>(false), typeof(T), null, 0, Address, 0U, Arguments));
		}

		
		public static T Call<T>(this IXboxConsole console, string module, int ordinal, params object[] Arguments) where T : struct
		{
			return (T)((object)JRPC.CallArgs(console, true, JRPC.TypeToType<T>(false), typeof(T), module, ordinal, 0U, 0U, Arguments));
		}

		
		public static T Call<T>(this IXboxConsole console, JRPC.ThreadType Type, uint Address, params object[] Arguments) where T : struct
		{
			return (T)((object)JRPC.CallArgs(console, Type == JRPC.ThreadType.System, JRPC.TypeToType<T>(false), typeof(T), null, 0, Address, 0U, Arguments));
		}

		
		public static T Call<T>(this IXboxConsole console, JRPC.ThreadType Type, string module, int ordinal, params object[] Arguments) where T : struct
		{
			return (T)((object)JRPC.CallArgs(console, Type == JRPC.ThreadType.System, JRPC.TypeToType<T>(false), typeof(T), module, ordinal, 0U, 0U, Arguments));
		}

		
		public static void CallVoid(this IXboxConsole console, uint Address, params object[] Arguments)
		{
			JRPC.CallArgs(console, true, JRPC.Void, typeof(void), null, 0, Address, 0U, Arguments);
		}

		
		public static void CallVoid(this IXboxConsole console, string module, int ordinal, params object[] Arguments)
		{
			JRPC.CallArgs(console, true, JRPC.Void, typeof(void), module, ordinal, 0U, 0U, Arguments);
		}

		
		public static void CallVoid(this IXboxConsole console, JRPC.ThreadType Type, uint Address, params object[] Arguments)
		{
			JRPC.CallArgs(console, Type == JRPC.ThreadType.System, JRPC.Void, typeof(void), null, 0, Address, 0U, Arguments);
		}

		
		public static void CallVoid(this IXboxConsole console, JRPC.ThreadType Type, string module, int ordinal, params object[] Arguments)
		{
			JRPC.CallArgs(console, Type == JRPC.ThreadType.System, JRPC.Void, typeof(void), module, ordinal, 0U, 0U, Arguments);
		}

		
		private static T[] ArrayReturn<T>(this IXboxConsole console, uint Address, uint Size)
		{
			if (Size == 0U)
			{
				return new T[1];
			}
			Type typeFromHandle = typeof(T);
			object obj = new object();
			if (typeFromHandle == typeof(short))
			{
				obj = console.ReadInt16(Address, Size);
			}
			if (typeFromHandle == typeof(ushort))
			{
				obj = console.ReadUInt16(Address, Size);
			}
			if (typeFromHandle == typeof(int))
			{
				obj = console.ReadInt32(Address, Size);
			}
			if (typeFromHandle == typeof(uint))
			{
				obj = console.ReadUInt32(Address, Size);
			}
			if (typeFromHandle == typeof(long))
			{
				obj = console.ReadInt64(Address, Size);
			}
			if (typeFromHandle == typeof(ulong))
			{
				obj = console.ReadUInt64(Address, Size);
			}
			if (typeFromHandle == typeof(float))
			{
				obj = console.ReadFloat(Address, Size);
			}
			if (typeFromHandle == typeof(byte))
			{
				obj = console.GetMemory(Address, Size);
			}
			return (T[])obj;
		}

		
		public static T[] CallArray<T>(this IXboxConsole console, uint Address, uint ArraySize, params object[] Arguments) where T : struct
		{
			if (ArraySize == 0U)
			{
				return new T[1];
			}
			uint address = (uint)JRPC.CallArgs(console, true, JRPC.TypeToType<T>(true), typeof(T), null, 0, Address, ArraySize, Arguments);
			return console.ArrayReturn(address, ArraySize);
		}

		
		public static T[] CallArray<T>(this IXboxConsole console, string module, int ordinal, uint ArraySize, params object[] Arguments) where T : struct
		{
			if (ArraySize == 0U)
			{
				return new T[1];
			}
			return (T[])JRPC.CallArgs(console, true, JRPC.TypeToType<T>(true), typeof(T), module, ordinal, 0U, ArraySize, Arguments);
		}

		
		public static T[] CallArray<T>(this IXboxConsole console, JRPC.ThreadType Type, uint Address, uint ArraySize, params object[] Arguments) where T : struct
		{
			if (ArraySize == 0U)
			{
				return new T[1];
			}
			return (T[])JRPC.CallArgs(console, Type == JRPC.ThreadType.System, JRPC.TypeToType<T>(true), typeof(T), null, 0, Address, ArraySize, Arguments);
		}

		
		public static T[] CallArray<T>(this IXboxConsole console, JRPC.ThreadType Type, string module, int ordinal, uint ArraySize, params object[] Arguments) where T : struct
		{
			if (ArraySize == 0U)
			{
				return new T[1];
			}
			return (T[])JRPC.CallArgs(console, Type == JRPC.ThreadType.System, JRPC.TypeToType<uint>(false), typeof(uint), module, ordinal, 0U, ArraySize, Arguments);
		}

		
		public static string CallString(this IXboxConsole console, uint Address, params object[] Arguments)
		{
			return (string)JRPC.CallArgs(console, true, JRPC.String, typeof(string), null, 0, Address, 0U, Arguments);
		}

		
		public static string CallString(this IXboxConsole console, string module, int ordinal, params object[] Arguments)
		{
			return (string)JRPC.CallArgs(console, true, JRPC.String, typeof(string), module, ordinal, 0U, 0U, Arguments);
		}

		
		public static string CallString(this IXboxConsole console, JRPC.ThreadType Type, uint Address, params object[] Arguments)
		{
			return (string)JRPC.CallArgs(console, Type == JRPC.ThreadType.System, JRPC.String, typeof(string), null, 0, Address, 0U, Arguments);
		}

		
		public static string CallString(this IXboxConsole console, JRPC.ThreadType Type, string module, int ordinal, params object[] Arguments)
		{
			return (string)JRPC.CallArgs(console, Type == JRPC.ThreadType.System, JRPC.String, typeof(string), module, ordinal, 0U, 0U, Arguments);
		}

		
		private static int UIntToInt(uint Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			return BitConverter.ToInt32(bytes, 0);
		}

		
		private static byte[] IntArrayToByte(int[] iArray)
		{
			byte[] array = new byte[iArray.Length * 4];
			int i = 0;
			int num = 0;
			while (i < iArray.Length)
			{
				for (int j = 0; j < 4; j++)
				{
					array[num + j] = BitConverter.GetBytes(iArray[i])[j];
				}
				i++;
				num += 4;
			}
			return array;
		}

		
		private static string SendCommand(IXboxConsole console, string Command)
		{
			uint num = JRPC.connectionId;
			string text;
			try
			{
				console.SendTextCommand(JRPC.connectionId, Command, out text);
				if (text.Contains("error="))
				{
					throw new Exception(text.Substring(11));
				}
				if (text.Contains("DEBUG"))
				{
					throw new Exception("JRPC is not installed on the current console");
				}
			}
			catch (COMException ex)
			{
				if (ex.ErrorCode == JRPC.UIntToInt(2195324935U))
				{
					throw new Exception("JRPC is not installed on the current console");
				}
				throw ex;
			}
			return text;
		}

		
		private static object CallArgs(IXboxConsole console, bool SystemThread, uint Type, Type t, string module, int ordinal, uint Address, uint ArraySize, params object[] Arguments)
		{
			if (!JRPC.IsValidReturnType(t))
			{
				throw new Exception(string.Concat(new object[]
				{
					"Invalid type ",
					t.Name,
					Environment.NewLine,
					"JRPC only supports: bool, byte, short, int, long, ushort, uint, ulong, float, double"
				}));
			}
			console.ConnectTimeout = (console.ConversationTimeout = 4000000U);
			string text = string.Concat(new object[]
			{
				"consolefeatures ver=",
				JRPC.JRPCVersion,
				" type=",
				Type,
				SystemThread ? " system" : "",
				(module != null) ? string.Concat(new object[]
				{
					" module=\"",
					module,
					"\" ord=",
					ordinal
				}) : "",
				" as=",
				ArraySize,
				" params=\"A\\",
				Address.ToString("X"),
				"\\A\\",
				Arguments.Length,
				"\\"
			});
			if (Arguments.Length > 37)
			{
				throw new Exception("Can not use more than 37 paramaters in a call");
			}
			foreach (object obj in Arguments)
			{
				bool flag = false;
				if (obj is uint)
				{
					object obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						JRPC.Int,
						"\\",
						JRPC.UIntToInt((uint)obj),
						"\\"
					});
					flag = true;
				}
				if (obj is int || obj is bool || obj is byte)
				{
					if (obj is bool)
					{
						object obj3 = text;
						text = string.Concat(new object[]
						{
							obj3,
							JRPC.Int,
							"/",
							Convert.ToInt32((bool)obj),
							"\\"
						});
					}
					else
					{
						object obj4 = text;
						text = string.Concat(new object[]
						{
							obj4,
							JRPC.Int,
							"\\",
							(obj is byte) ? Convert.ToByte(obj).ToString() : Convert.ToInt32(obj).ToString(),
							"\\"
						});
					}
					flag = true;
				}
				else if (obj is int[] || obj is uint[])
				{
					byte[] array = JRPC.IntArrayToByte((int[])obj);
					object obj5 = text;
					text = string.Concat(new object[]
					{
						obj5,
						JRPC.ByteArray.ToString(),
						"/",
						array.Length,
						"\\"
					});
					for (int j = 0; j < array.Length; j++)
					{
						text += array[j].ToString("X2");
					}
					text += "\\";
					flag = true;
				}
				else if (obj is string)
				{
					string text2 = (string)obj;
					object obj6 = text;
					text = string.Concat(new object[]
					{
						obj6,
						JRPC.ByteArray.ToString(),
						"/",
						text2.Length,
						"\\",
						((string)obj).ToHexString(),
						"\\"
					});
					flag = true;
				}
				else if (obj is double)
				{
					double num = (double)obj;
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						JRPC.Float.ToString(),
						"\\",
						num.ToString(),
						"\\"
					});
					flag = true;
				}
				else if (obj is float)
				{
					float num2 = (float)obj;
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						JRPC.Float.ToString(),
						"\\",
						num2.ToString(),
						"\\"
					});
					flag = true;
				}
				else if (obj is float[])
				{
					float[] array2 = (float[])obj;
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						JRPC.ByteArray.ToString(),
						"/",
						(array2.Length * 4).ToString(),
						"\\"
					});
					for (int k = 0; k < array2.Length; k++)
					{
						byte[] bytes = BitConverter.GetBytes(array2[k]);
						Array.Reverse(bytes);
						for (int l = 0; l < 4; l++)
						{
							text += bytes[l].ToString("X2");
						}
					}
					text += "\\";
					flag = true;
				}
				else if (obj is byte[])
				{
					byte[] array3 = (byte[])obj;
					object obj2 = text;
					text = string.Concat(new object[]
					{
						obj2,
						JRPC.ByteArray.ToString(),
						"/",
						array3.Length,
						"\\"
					});
					for (int m = 0; m < array3.Length; m++)
					{
						text += array3[m].ToString("X2");
					}
					text += "\\";
					flag = true;
				}
				if (!flag)
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						JRPC.Uint64.ToString(),
						"\\",
						JRPC.ConvertToUInt64(obj).ToString(),
						"\\"
					});
				}
			}
			text += "\"";
			string text4 = JRPC.SendCommand(console, text);
			string text5 = "buf_addr=";
			while (text4.Contains(text5))
			{
				Thread.Sleep(250);
				text4 = JRPC.SendCommand(console, "consolefeatures " + text5 + "0x" + uint.Parse(text4.Substring(text4.find(text5) + text5.Length), NumberStyles.HexNumber).ToString("X"));
			}
			console.ConversationTimeout = 2000U;
			console.ConnectTimeout = 5000U;
			switch (Type)
			{
			case 1U:
			{
				uint num3 = uint.Parse(text4.Substring(text4.find(" ") + 1), NumberStyles.HexNumber);
				if (t == typeof(uint))
				{
					return num3;
				}
				if (t == typeof(int))
				{
					return JRPC.UIntToInt(num3);
				}
				if (t == typeof(short))
				{
					return short.Parse(text4.Substring(text4.find(" ") + 1), NumberStyles.HexNumber);
				}
				if (t == typeof(ushort))
				{
					return ushort.Parse(text4.Substring(text4.find(" ") + 1), NumberStyles.HexNumber);
				}
				break;
			}
			case 2U:
			{
				string text6 = text4.Substring(text4.find(" ") + 1);
				if (t == typeof(string))
				{
					return text6;
				}
				if (t == typeof(char[]))
				{
					return text6.ToCharArray();
				}
				break;
			}
			case 3U:
				if (t == typeof(double))
				{
					return double.Parse(text4.Substring(text4.find(" ") + 1));
				}
				if (t == typeof(float))
				{
					return float.Parse(text4.Substring(text4.find(" ") + 1));
				}
				break;
			case 4U:
			{
				byte b = byte.Parse(text4.Substring(text4.find(" ") + 1), NumberStyles.HexNumber);
				if (t == typeof(byte))
				{
					return b;
				}
				if (t == typeof(char))
				{
					return (char)b;
				}
				break;
			}
			case 8U:
				if (t == typeof(long))
				{
					return long.Parse(text4.Substring(text4.find(" ") + 1), NumberStyles.HexNumber);
				}
				if (t == typeof(ulong))
				{
					return ulong.Parse(text4.Substring(text4.find(" ") + 1), NumberStyles.HexNumber);
				}
				break;
			}
			if (Type == 5U)
			{
				string text7 = text4.Substring(text4.find(" ") + 1);
				int num4 = 0;
				string text8 = "";
				uint[] array4 = new uint[8];
				foreach (char c in text7)
				{
					if (c != ',' && c != ';')
					{
						text8 += c.ToString();
					}
					else
					{
						array4[num4] = uint.Parse(text8, NumberStyles.HexNumber);
						num4++;
						text8 = "";
					}
					if (c == ';')
					{
						break;
					}
				}
				return array4;
			}
			if (Type == 6U)
			{
				string text10 = text4.Substring(text4.find(" ") + 1);
				int num5 = 0;
				string text11 = "";
				float[] array5 = new float[ArraySize];
				foreach (char c2 in text10)
				{
					if (c2 != ',' && c2 != ';')
					{
						text11 += c2.ToString();
					}
					else
					{
						array5[num5] = float.Parse(text11);
						num5++;
						text11 = "";
					}
					if (c2 == ';')
					{
						break;
					}
				}
				return array5;
			}
			if (Type == 7U)
			{
				string text12 = text4.Substring(text4.find(" ") + 1);
				int num6 = 0;
				string text13 = "";
				byte[] array6 = new byte[ArraySize];
				foreach (char c3 in text12)
				{
					if (c3 != ',' && c3 != ';')
					{
						text13 += c3.ToString();
					}
					else
					{
						array6[num6] = byte.Parse(text13);
						num6++;
						text13 = "";
					}
					if (c3 == ';')
					{
						break;
					}
				}
				return array6;
			}
			if (Type == JRPC.Uint64Array)
			{
				string text14 = text4.Substring(text4.find(" ") + 1);
				int num7 = 0;
				string text15 = "";
				ulong[] array7 = new ulong[ArraySize];
				foreach (char c4 in text14)
				{
					if (c4 != ',' && c4 != ';')
					{
						text15 += c4.ToString();
					}
					else
					{
						array7[num7] = ulong.Parse(text15);
						num7++;
						text15 = "";
					}
					if (c4 == ';')
					{
						break;
					}
				}
				if (t == typeof(ulong))
				{
					return array7;
				}
				if (t == typeof(long))
				{
					long[] array8 = new long[ArraySize];
					int num8 = 0;
					while ((long)num8 < (long)((ulong)ArraySize))
					{
						array8[num8] = BitConverter.ToInt64(BitConverter.GetBytes(array7[num8]), 0);
						num8++;
					}
					return array8;
				}
			}
			if (Type == JRPC.Void)
			{
				return 0;
			}
			return ulong.Parse(text4.Substring(text4.find(" ") + 1), NumberStyles.HexNumber);
		}

		
		private static readonly uint Void = 0U;

		
		private static readonly uint Int = 1U;

		
		private static readonly uint String = 2U;

		
		private static readonly uint Float = 3U;

		
		private static readonly uint Byte = 4U;

		
		private static readonly uint IntArray = 5U;

		
		private static readonly uint FloatArray = 6U;

		
		private static readonly uint ByteArray = 7U;

		
		private static readonly uint Uint64 = 8U;

		
		private static readonly uint Uint64Array = 9U;

		
		private static uint connectionId;

		
		public static readonly uint JRPCVersion = 2U;

		
		private static Dictionary<Type, int> ValueTypeSizeMap = new Dictionary<Type, int>
		{
			{
				typeof(bool),
				4
			},
			{
				typeof(byte),
				1
			},
			{
				typeof(short),
				2
			},
			{
				typeof(int),
				4
			},
			{
				typeof(long),
				8
			},
			{
				typeof(ushort),
				2
			},
			{
				typeof(uint),
				4
			},
			{
				typeof(ulong),
				8
			},
			{
				typeof(float),
				4
			},
			{
				typeof(double),
				8
			}
		};

		
		private static Dictionary<Type, int> StructPrimitiveSizeMap = new Dictionary<Type, int>();

		
		private static HashSet<Type> ValidReturnTypes = new HashSet<Type>
		{
			typeof(void),
			typeof(bool),
			typeof(byte),
			typeof(short),
			typeof(int),
			typeof(long),
			typeof(ushort),
			typeof(uint),
			typeof(ulong),
			typeof(float),
			typeof(double),
			typeof(string),
			typeof(bool[]),
			typeof(byte[]),
			typeof(short[]),
			typeof(int[]),
			typeof(long[]),
			typeof(ushort[]),
			typeof(uint[]),
			typeof(ulong[]),
			typeof(float[]),
			typeof(double[]),
			typeof(string[])
		};

		
		public enum LEDState
		{
			
			OFF,
			
			RED = 8,
			
			GREEN = 128,
			
			ORANGE = 136
		}

		
		public enum TemperatureType
		{
			
			CPU,
			
			GPU,
			
			EDRAM,
			
			MotherBoard
		}

		
		public enum ThreadType
		{
			
			System,
			
			Title
		}
	}
}
