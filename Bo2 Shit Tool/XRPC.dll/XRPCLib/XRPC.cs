using System;
using System.Text;
using System.Threading;
using XDevkit;

namespace XRPCLib
{
	
	public class XRPC
	{
		
		public void Connect()
		{
			this.initialize();
			if (this.activeConnection && this.sa == 0)
			{
				this.sa = 1;
			}
		}

		
		public void initialize()
		{
			if (!this.activeConnection)
			{
				this.xboxMgr = new XboxManagerClass();
				this.xbCon = this.xboxMgr.OpenConsole(this.xboxMgr.DefaultConsole);
				try
				{
					this.xbConnection = this.xbCon.OpenConnection(null);
				}
				catch (Exception)
				{
					return;
				}
				string text;
				string text2;
				if (this.xbCon.DebugTarget.IsDebuggerConnected(out text, out text2))
				{
					this.activeConnection = true;
					return;
				}
				this.xbCon.DebugTarget.ConnectAsDebugger("XRPC", XboxDebugConnectFlags.Force);
				if (!this.xbCon.DebugTarget.IsDebuggerConnected(out text, out text2))
				{
					return;
				}
				this.activeConnection = true;
				return;
			}
			else
			{
				string text;
				string text2;
				if (this.xbCon.DebugTarget.IsDebuggerConnected(out text, out text2))
				{
					return;
				}
				this.activeConnection = false;
				this.Connect();
			}
		}

		
		public byte[] GetMemory(uint address, uint length)
		{
			byte[] array = new byte[length];
			this.xbCon.DebugTarget.GetMemory(address, length, array, out XRPC.g);
			this.xbCon.DebugTarget.InvalidateMemoryCache(true, address, length);
			return array;
		}

		
		public byte[] WideChar(string text)
		{
			byte[] array = new byte[text.Length * 2 + 2];
			int num = 1;
			array[0] = 0;
			foreach (char value in text)
			{
				array[num] = Convert.ToByte(value);
				num += 2;
			}
			return array;
		}

		
		public void SetMemory(uint address, byte[] data)
		{
			this.xbCon.DebugTarget.SetMemory(address, (uint)data.Length, data, out XRPC.g);
		}

		
		private static byte[] getData(long[] argument)
		{
			byte[] array = new byte[argument.Length * 8];
			int num = 0;
			foreach (long value in argument)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				Array.Reverse(bytes);
				bytes.CopyTo(array, num);
				num += 8;
			}
			return array;
		}

		
		public uint SystemCall(params object[] arg)
		{
			long[] array = new long[9];
			if (!this.activeConnection)
			{
				this.Connect();
			}
			if (XRPC.firstRan == 0)
			{
				byte[] array2 = new byte[4];
				this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, array2, out XRPC.meh);
				this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
				Array.Reverse(array2);
				this.bufferAddress = BitConverter.ToUInt32(array2, 0);
				XRPC.firstRan = 1;
				this.stringPointer = this.bufferAddress + 1500U;
				this.floatPointer = this.bufferAddress + 2700U;
				this.bytePointer = this.bufferAddress + 3200U;
				this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 100U, this.nulled, out XRPC.meh);
				this.xbCon.DebugTarget.SetMemory(this.stringPointer, 100U, this.nulled, out XRPC.meh);
			}
			if (this.bufferAddress == 0U)
			{
				byte[] array3 = new byte[4];
				this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, array3, out XRPC.meh);
				this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
				Array.Reverse(array3);
				this.bufferAddress = BitConverter.ToUInt32(array3, 0);
			}
			this.stringPointer = this.bufferAddress + 1500U;
			this.floatPointer = this.bufferAddress + 2700U;
			this.bytePointer = this.bufferAddress + 3200U;
			int num = 0;
			int num2 = 0;
			foreach (object obj in arg)
			{
				if (obj is byte)
				{
					byte[] value = (byte[])obj;
					array[num2] = (long)((ulong)BitConverter.ToUInt32(value, 0));
				}
				else if (obj is byte[])
				{
					byte[] array4 = (byte[])obj;
					this.xbCon.DebugTarget.SetMemory(this.bytePointer, (uint)array4.Length, array4, out XRPC.meh);
					array[num2] = (long)((ulong)this.bytePointer);
					this.bytePointer += (uint)(array4.Length + 2);
				}
				else if (obj is float)
				{
					float value2 = float.Parse(Convert.ToString(obj));
					byte[] bytes = BitConverter.GetBytes(value2);
					this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint)bytes.Length, bytes, out XRPC.meh);
					array[num2] = (long)((ulong)this.floatPointer);
					this.floatPointer += (uint)(bytes.Length + 2);
				}
				else if (obj is float[])
				{
					byte[] array5 = new byte[12];
					for (int j = 0; j <= 2; j++)
					{
						byte[] array6 = new byte[4];
						Buffer.BlockCopy((Array)obj, j * 4, array6, 0, 4);
						Array.Reverse(array6);
						Buffer.BlockCopy(array6, 0, array5, 4 * j, 4);
					}
					this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint)array5.Length, array5, out XRPC.meh);
					array[num2] = (long)((ulong)this.floatPointer);
					this.floatPointer += 2U;
				}
				else if (obj is string)
				{
					byte[] bytes2 = Encoding.ASCII.GetBytes(Convert.ToString(obj));
					this.xbCon.DebugTarget.SetMemory(this.stringPointer, (uint)bytes2.Length, bytes2, out XRPC.meh);
					array[num2] = (long)((ulong)this.stringPointer);
					string text = Convert.ToString(obj);
					this.stringPointer += (uint)(text.Length + 1);
				}
				else
				{
					array[num2] = Convert.ToInt64(obj);
				}
				num++;
				num2++;
			}
			byte[] data = XRPC.getData(array);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 8U, (uint)data.Length, data, out XRPC.meh);
			byte[] bytes3 = BitConverter.GetBytes(num);
			Array.Reverse(bytes3);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 4U, 4U, bytes3, out XRPC.meh);
			Thread.Sleep(0);
			byte[] bytes4 = BitConverter.GetBytes(2181038080U);
			Array.Reverse(bytes4);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 4U, bytes4, out XRPC.meh);
			Thread.Sleep(50);
			byte[] array7 = new byte[4];
			this.xbCon.DebugTarget.GetMemory(this.bufferAddress + 4092U, 4U, array7, out XRPC.meh);
			this.xbCon.DebugTarget.InvalidateMemoryCache(true, this.bufferAddress + 4092U, 4U);
			Array.Reverse(array7);
			return BitConverter.ToUInt32(array7, 0);
		}

		
		public uint ResolveFunction(string titleID, uint ord)
		{
			if (XRPC.firstRan == 0)
			{
				byte[] array = new byte[4];
				this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, array, out XRPC.meh);
				this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
				Array.Reverse(array);
				this.bufferAddress = BitConverter.ToUInt32(array, 0);
				XRPC.firstRan = 1;
				this.stringPointer = this.bufferAddress + 1500U;
				this.floatPointer = this.bufferAddress + 2700U;
				this.bytePointer = this.bufferAddress + 3200U;
				this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 100U, this.nulled, out XRPC.meh);
				this.xbCon.DebugTarget.SetMemory(this.stringPointer, 100U, this.nulled, out XRPC.meh);
			}
			byte[] bytes = Encoding.ASCII.GetBytes(titleID);
			this.xbCon.DebugTarget.SetMemory(this.stringPointer, (uint)bytes.Length, bytes, out XRPC.meh);
			long[] array2 = new long[2];
			array2[0] = (long)((ulong)this.stringPointer);
			string text = Convert.ToString(titleID);
			this.stringPointer += (uint)(text.Length + 1);
			array2[1] = (long)((ulong)ord);
			byte[] data = XRPC.getData(array2);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 8U, (uint)data.Length, data, out XRPC.meh);
			byte[] bytes2 = BitConverter.GetBytes(2181038081U);
			Array.Reverse(bytes2);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 4U, bytes2, out XRPC.meh);
			Thread.Sleep(50);
			byte[] array3 = new byte[4];
			this.xbCon.DebugTarget.GetMemory(this.bufferAddress + 4092U, 4U, array3, out XRPC.meh);
			this.xbCon.DebugTarget.InvalidateMemoryCache(true, this.bufferAddress + 4092U, 4U);
			Array.Reverse(array3);
			return BitConverter.ToUInt32(array3, 0);
		}

		
		public void Notify(XRPC.XNotiyLogo type, string text)
		{
			byte[] array = this.WideChar(text);
			this.SystemCall(new object[]
			{
				this.ResolveFunction("xam.xex", 656U),
				Convert.ToUInt32(type),
				0,
				2,
				array,
				0
			});
		}

		
		private float[] toFloatArray(double[] arr)
		{
			if (arr == null)
			{
				return null;
			}
			int num = arr.Length;
			float[] array = new float[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (float)arr[i];
			}
			return array;
		}

		
		public uint Call(uint address, params object[] arg)
		{
			long[] array = new long[9];
			if (!this.activeConnection)
			{
				this.Connect();
			}
			if (XRPC.firstRan == 0)
			{
				byte[] array2 = new byte[4];
				this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, array2, out XRPC.meh);
				this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
				Array.Reverse(array2);
				this.bufferAddress = BitConverter.ToUInt32(array2, 0);
				XRPC.firstRan = 1;
				this.stringPointer = this.bufferAddress + 1500U;
				this.floatPointer = this.bufferAddress + 2700U;
				this.bytePointer = this.bufferAddress + 3200U;
				this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 100U, this.nulled, out XRPC.meh);
				this.xbCon.DebugTarget.SetMemory(this.stringPointer, 100U, this.nulled, out XRPC.meh);
			}
			if (this.bufferAddress == 0U)
			{
				byte[] array3 = new byte[4];
				this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, array3, out XRPC.meh);
				this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
				Array.Reverse(array3);
				this.bufferAddress = BitConverter.ToUInt32(array3, 0);
			}
			this.stringPointer = this.bufferAddress + 1500U;
			this.floatPointer = this.bufferAddress + 2700U;
			this.bytePointer = this.bufferAddress + 3200U;
			int num = 0;
			int num2 = 0;
			foreach (object obj in arg)
			{
				if (obj is byte)
				{
					byte[] value = (byte[])obj;
					array[num2] = (long)((ulong)BitConverter.ToUInt32(value, 0));
				}
				else if (obj is byte[])
				{
					byte[] array4 = (byte[])obj;
					this.xbCon.DebugTarget.SetMemory(this.bytePointer, (uint)array4.Length, array4, out XRPC.meh);
					array[num2] = (long)((ulong)this.bytePointer);
					this.bytePointer += (uint)(array4.Length + 2);
				}
				else if (obj is float)
				{
					float value2 = float.Parse(Convert.ToString(obj));
					byte[] bytes = BitConverter.GetBytes(value2);
					this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint)bytes.Length, bytes, out XRPC.meh);
					array[num2] = (long)((ulong)this.floatPointer);
					this.floatPointer += (uint)(bytes.Length + 2);
				}
				else if (obj is float[])
				{
					byte[] array5 = new byte[12];
					for (int j = 0; j <= 2; j++)
					{
						byte[] array6 = new byte[4];
						Buffer.BlockCopy((Array)obj, j * 4, array6, 0, 4);
						Array.Reverse(array6);
						Buffer.BlockCopy(array6, 0, array5, 4 * j, 4);
					}
					this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint)array5.Length, array5, out XRPC.meh);
					array[num2] = (long)((ulong)this.floatPointer);
					this.floatPointer += 2U;
				}
				else if (obj is string)
				{
					byte[] bytes2 = Encoding.ASCII.GetBytes(Convert.ToString(obj));
					this.xbCon.DebugTarget.SetMemory(this.stringPointer, (uint)bytes2.Length, bytes2, out XRPC.meh);
					array[num2] = (long)((ulong)this.stringPointer);
					string text = Convert.ToString(obj);
					this.stringPointer += (uint)(text.Length + 1);
				}
				else
				{
					array[num2] = Convert.ToInt64(obj);
				}
				num++;
				num2++;
			}
			byte[] data = XRPC.getData(array);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 8U, (uint)data.Length, data, out XRPC.meh);
			byte[] bytes3 = BitConverter.GetBytes(num);
			Array.Reverse(bytes3);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 4U, 4U, bytes3, out XRPC.meh);
			Thread.Sleep(0);
			byte[] bytes4 = BitConverter.GetBytes(address);
			Array.Reverse(bytes4);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 4U, bytes4, out XRPC.meh);
			Thread.Sleep(50);
			byte[] array7 = new byte[4];
			this.xbCon.DebugTarget.GetMemory(this.bufferAddress + 4092U, 4U, array7, out XRPC.meh);
			this.xbCon.DebugTarget.InvalidateMemoryCache(true, this.bufferAddress + 4092U, 4U);
			Array.Reverse(array7);
			return BitConverter.ToUInt32(array7, 0);
		}

		
		public uint CallSysFunction(uint address, params object[] arg)
		{
			long[] array = new long[9];
			if (!this.activeConnection)
			{
				this.Connect();
			}
			if (XRPC.firstRan == 0)
			{
				byte[] array2 = new byte[4];
				this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, array2, out XRPC.meh);
				this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
				Array.Reverse(array2);
				this.bufferAddress = BitConverter.ToUInt32(array2, 0);
				XRPC.firstRan = 1;
				this.stringPointer = this.bufferAddress + 1500U;
				this.floatPointer = this.bufferAddress + 2700U;
				this.bytePointer = this.bufferAddress + 3200U;
				this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 100U, this.nulled, out XRPC.meh);
				this.xbCon.DebugTarget.SetMemory(this.stringPointer, 100U, this.nulled, out XRPC.meh);
			}
			if (this.bufferAddress == 0U)
			{
				byte[] array3 = new byte[4];
				this.xbCon.DebugTarget.GetMemory(2445314222U, 4U, array3, out XRPC.meh);
				this.xbCon.DebugTarget.InvalidateMemoryCache(true, 2445314222U, 4U);
				Array.Reverse(array3);
				this.bufferAddress = BitConverter.ToUInt32(array3, 0);
			}
			this.stringPointer = this.bufferAddress + 1500U;
			this.floatPointer = this.bufferAddress + 2700U;
			this.bytePointer = this.bufferAddress + 3200U;
			int num = 0;
			int num2 = 0;
			array[num2] = (long)((ulong)address);
			num2++;
			foreach (object obj in arg)
			{
				if (obj is byte)
				{
					byte[] value = (byte[])obj;
					array[num2] = (long)((ulong)BitConverter.ToUInt32(value, 0));
				}
				else if (obj is byte[])
				{
					byte[] array4 = (byte[])obj;
					this.xbCon.DebugTarget.SetMemory(this.bytePointer, (uint)array4.Length, array4, out XRPC.meh);
					array[num2] = (long)((ulong)this.bytePointer);
					this.bytePointer += (uint)(array4.Length + 2);
				}
				else if (obj is float)
				{
					float value2 = float.Parse(Convert.ToString(obj));
					byte[] bytes = BitConverter.GetBytes(value2);
					this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint)bytes.Length, bytes, out XRPC.meh);
					array[num2] = (long)((ulong)this.floatPointer);
					this.floatPointer += (uint)(bytes.Length + 2);
				}
				else if (obj is float[])
				{
					byte[] array5 = new byte[12];
					for (int j = 0; j <= 2; j++)
					{
						byte[] array6 = new byte[4];
						Buffer.BlockCopy((Array)obj, j * 4, array6, 0, 4);
						Array.Reverse(array6);
						Buffer.BlockCopy(array6, 0, array5, 4 * j, 4);
					}
					this.xbCon.DebugTarget.SetMemory(this.floatPointer, (uint)array5.Length, array5, out XRPC.meh);
					array[num2] = (long)((ulong)this.floatPointer);
					this.floatPointer += 2U;
				}
				else if (obj is string)
				{
					byte[] bytes2 = Encoding.ASCII.GetBytes(Convert.ToString(obj));
					this.xbCon.DebugTarget.SetMemory(this.stringPointer, (uint)bytes2.Length, bytes2, out XRPC.meh);
					array[num2] = (long)((ulong)this.stringPointer);
					string text = Convert.ToString(obj);
					this.stringPointer += (uint)(text.Length + 1);
				}
				else
				{
					array[num2] = Convert.ToInt64(obj);
				}
				num++;
				num2++;
			}
			byte[] data = XRPC.getData(array);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 8U, (uint)data.Length, data, out XRPC.meh);
			byte[] bytes3 = BitConverter.GetBytes(num);
			Array.Reverse(bytes3);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress + 4U, 4U, bytes3, out XRPC.meh);
			Thread.Sleep(0);
			byte[] bytes4 = BitConverter.GetBytes(2181038080U);
			Array.Reverse(bytes4);
			this.xbCon.DebugTarget.SetMemory(this.bufferAddress, 4U, bytes4, out XRPC.meh);
			Thread.Sleep(50);
			byte[] array7 = new byte[4];
			this.xbCon.DebugTarget.GetMemory(this.bufferAddress + 4092U, 4U, array7, out XRPC.meh);
			this.xbCon.DebugTarget.InvalidateMemoryCache(true, this.bufferAddress + 4092U, 4U);
			Array.Reverse(array7);
			return BitConverter.ToUInt32(array7, 0);
		}

		
		public bool activeConnection;

		
		public bool activeTransfer;

		
		public IXboxManager xboxMgr;

		
		public 

		
		private uint xbConnection;

		
		private int sa;

		
		public static uint g;

		
		private string currentVersion = "1.7";

		
		private static uint meh;

		
		private static int firstRan;

		
		private uint bufferAddressRead = 2445323722U;

		
		private uint bufferAddress;

		
		private uint stringPointer;

		
		private uint floatPointer;

		
		private uint bytePointer;

		
		private byte[] nulled = new byte[100];

		
		private uint[] buffcheck = new uint[15];

		
		private int multiple;

		
		public struct wChar
		{
			
			public string Text;
		}

		
		public enum XNotiyLogo
		{
			
			XBOX_LOGO,
			
			NEW_MESSAGE_LOGO,
			
			FRIEND_REQUEST_LOGO,
			
			NEW_MESSAGE,
			
			FLASHING_XBOX_LOGO,
			
			GAMERTAG_SENT_YOU_A_MESSAGE,
			
			GAMERTAG_SINGED_OUT,
			
			GAMERTAG_SIGNEDIN,
			
			GAMERTAG_SIGNED_INTO_XBOX_LIVE,
			
			GAMERTAG_SIGNED_IN_OFFLINE,
			
			GAMERTAG_WANTS_TO_CHAT,
			
			DISCONNECTED_FROM_XBOX_LIVE,
			
			DOWNLOAD,
			
			FLASHING_MUSIC_SYMBOL,
			
			FLASHING_HAPPY_FACE,
			
			FLASHING_FROWNING_FACE,
			
			FLASHING_DOUBLE_SIDED_HAMMER,
			
			GAMERTAG_WANTS_TO_CHAT_2,
			
			PLEASE_REINSERT_MEMORY_UNIT,
			
			PLEASE_RECONNECT_CONTROLLERM,
			
			GAMERTAG_HAS_JOINED_CHAT,
			
			GAMERTAG_HAS_LEFT_CHAT,
			
			GAME_INVITE_SENT,
			
			FLASH_LOGO,
			
			PAGE_SENT_TO,
			
			FOUR_2,
			
			FOUR_3,
			
			ACHIEVEMENT_UNLOCKED,
			
			FOUR_9,
			
			GAMERTAG_WANTS_TO_TALK_IN_VIDEO_KINECT,
			
			VIDEO_CHAT_INVITE_SENT,
			
			READY_TO_PLAY,
			
			CANT_DOWNLOAD_X,
			
			DOWNLOAD_STOPPED_FOR_X,
			
			FLASHING_XBOX_CONSOLE,
			
			X_SENT_YOU_A_GAME_MESSAGE,
			
			DEVICE_FULL,
			
			FOUR_7,
			
			FLASHING_CHAT_ICON,
			
			ACHIEVEMENTS_UNLOCKED,
			
			X_HAS_SENT_YOU_A_NUDGE,
			
			MESSENGER_DISCONNECTED,
			
			BLANK,
			
			CANT_SIGN_IN_MESSENGER,
			
			MISSED_MESSENGER_CONVERSATION,
			
			FAMILY_TIMER_X_TIME_REMAINING,
			
			DISCONNECTED_XBOX_LIVE_11_MINUTES_REMAINING,
			
			KINECT_HEALTH_EFFECTS,
			
			FOUR_5,
			
			GAMERTAG_WANTS_YOU_TO_JOIN_AN_XBOX_LIVE_PARTY,
			
			PARTY_INVITE_SENT,
			
			GAME_INVITE_SENT_TO_XBOX_LIVE_PARTY,
			
			KICKED_FROM_XBOX_LIVE_PARTY,
			
			NULLED,
			
			DISCONNECTED_XBOX_LIVE_PARTY,
			
			DOWNLOADED,
			
			CANT_CONNECT_XBL_PARTY,
			
			GAMERTAG_HAS_JOINED_XBL_PARTY,
			
			GAMERTAG_HAS_LEFT_XBL_PARTY,
			
			GAMER_PICTURE_UNLOCKED,
			
			AVATAR_AWARD_UNLOCKED,
			
			JOINED_XBL_PARTY,
			
			PLEASE_REINSERT_USB_STORAGE_DEVICE,
			
			PLAYER_MUTED,
			
			PLAYER_UNMUTED,
			
			FLASHING_CHAT_SYMBOL,
			
			UPDATING = 76
		}
	}
}
