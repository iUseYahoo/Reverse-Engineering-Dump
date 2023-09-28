using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using XDevkit;
using XRPCLib;

namespace Shit_Tool
{
	
	public class Form3 : Form
	{
		
		public Form3()
		{
			this.InitializeComponent();
		}

		
		private void Form3_Load(object sender, EventArgs e)
		{
			this.uint_0 = 2186077008U;
			this.uint_1 = 2187549396U;
			this.uint_2 = 2209090056U;
			this.uint_3 = 2185429112U;
			this.uint_4 = 2181667144U;
			this.uint_5 = 2184440024U;
			this.uint_6 = 2184597016U;
			this.uint_7 = 2184248664U;
			this.uint_8 = 2184353872U;
			this.uint_9 = 2218083272U;
			this.uint_10 = 2185237984U;
			this.uint_11 = 2185427824U;
			this.webClient_0 = new WebClient();
			this.uint_12 = 2188475720U;
			this.uint_13 = 2185545528U;
			this.uint_14 = 2186122728U;
			this.xrpc_0 = new XRPC();
			this.uint_15 = 2183285288U;
			this.uint_16 = 2183481664U;
			this.uint_17 = 2183692000U;
			this.uint_18 = 2183959160U;
			this.uint_19 = 2218037670U;
			this.uint_20 = 2218080975U;
			this.uint_21 = 2218080946U;
			this.uint_22 = 2218080961U;
			this.string_0 = "2.1.0";
			this.uint_23 = 2183593736U;
			this.uint_24 = 2183684008U;
			this.webClient_1 = new WebClient();
			this.xrpc_0.Connect();
			if (this.xrpc_0.activeConnection)
			{
				this.label_0.Text = "Connected";
			}
			else
			{
				this.label_0.Text = "Unable to Connect";
			}
			byte[] array = new byte[4];
			array[0] = 96;
			this.byte_10 = array;
			this.byte_13 = new byte[]
			{
				96,
				0,
				0,
				0,
				96,
				0,
				0,
				0,
				96,
				0,
				0,
				0,
				96,
				0,
				0,
				0,
				96,
				0,
				0,
				0
			};
			this.byte_11 = new byte[]
			{
				56,
				192,
				0,
				10
			};
			this.byte_6 = new byte[]
			{
				56,
				192,
				0,
				22
			};
			this.byte_12 = new byte[]
			{
				127,
				198,
				243,
				120
			};
			this.byte_2 = new byte[]
			{
				56,
				192,
				byte.MaxValue,
				byte.MaxValue
			};
			this.byte_1 = new byte[]
			{
				127,
				166,
				235,
				18
			};
			this.byte_14 = new byte[]
			{
				59,
				160,
				0,
				1
			};
			this.byte_7 = new byte[]
			{
				47,
				16,
				0,
				1
			};
			array = new byte[4];
			array[0] = 128;
			array[1] = 112;
			this.byte_9 = array;
			this.byte_0 = new byte[]
			{
				37,
				117,
				36,
				70
			};
			this.byte_4 = new byte[]
			{
				97
			};
			this.byte_3 = new byte[]
			{
				116
			};
			this.byte_8 = new byte[]
			{
				0,
				0,
				15,
				0,
				0,
				0,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				0,
				0,
				0,
				54,
				0,
				0,
				0,
				0,
				0,
				76,
				15,
				19
			};
			this.byte_5 = new byte[]
			{
				137,
				107,
				0,
				12
			};
			this.icontainer_0 = null;
		}

		
		private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_0.Text == "B23R")
			{
				byte[] array = new byte[]
				{
					0,
					17
				};
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "KAP-40")
			{
				byte[] array = new byte[]
				{
					0,
					10
				};
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "Five-Seven")
			{
				byte[] array = new byte[]
				{
					0,
					25
				};
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "Tac-45")
			{
				byte[] array = new byte[]
				{
					0,
					12
				};
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "Executioner")
			{
				byte[] array = new byte[]
				{
					0,
					22
				};
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "RPG")
			{
				byte[] array = new byte[4];
				array[1] = 221;
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "SMAW")
			{
				this.xrpc_0.SetMemory(2218080946U, new byte[]
				{
					0,
					215,
					132,
					192
				});
			}
			if (this.comboBox_0.Text == "FHJ-18 AA")
			{
				byte[] array = new byte[4];
				array[1] = 218;
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "Crossbow")
			{
				byte[] array = new byte[4];
				array[1] = 234;
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "Ballistic Knife")
			{
				byte[] array = new byte[4];
				array[1] = 238;
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "B23R Dual Wield")
			{
				byte[] array = new byte[]
				{
					0,
					44
				};
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "KAP-40 Dual Wield")
			{
				byte[] array = new byte[]
				{
					0,
					28
				};
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "Five-Seven Dual Wield")
			{
				byte[] array = new byte[]
				{
					0,
					36
				};
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "Tac-45 Dual Wield")
			{
				byte[] array = new byte[]
				{
					0,
					34
				};
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "Executioner Dual Wield")
			{
				byte[] array = new byte[]
				{
					0,
					42
				};
				this.xrpc_0.SetMemory(2218080946U, array);
			}
			if (this.comboBox_0.Text == "MP7")
			{
				byte[] data = new byte[]
				{
					0,
					53
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "Skorpion EVO")
			{
				byte[] data = new byte[]
				{
					0,
					56
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "Chicom CQB")
			{
				byte[] data = new byte[]
				{
					0,
					64
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "MSMC")
			{
				byte[] data = new byte[]
				{
					0,
					68
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "Vector K10")
			{
				byte[] data = new byte[]
				{
					0,
					72
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "M8A1")
			{
				byte[] data = new byte[]
				{
					0,
					96
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "SCAR-H")
			{
				byte[] data = new byte[]
				{
					0,
					100
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "AN-94")
			{
				byte[] data = new byte[]
				{
					0,
					104
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "Type 25")
			{
				byte[] data = new byte[]
				{
					0,
					114
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "FAL OSW")
			{
				byte[] data = new byte[]
				{
					0,
					118
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "MTAR")
			{
				byte[] data = new byte[]
				{
					0,
					128
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "MK 48")
			{
				byte[] data = new byte[]
				{
					0,
					144
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "QBB LSW")
			{
				byte[] data = new byte[]
				{
					0,
					148
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "LSAT")
			{
				byte[] data = new byte[]
				{
					0,
					152
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "SMR")
			{
				byte[] data = new byte[]
				{
					0,
					122
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "HAMR")
			{
				byte[] data = new byte[]
				{
					0,
					156
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "PDW-57")
			{
				byte[] data = new byte[]
				{
					0,
					60
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "Peacekeeper")
			{
				byte[] data = new byte[]
				{
					0,
					76
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "SWAT-556")
			{
				byte[] data = new byte[]
				{
					0,
					108
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "M27")
			{
				byte[] data = new byte[]
				{
					0,
					124
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "Ballista")
			{
				byte[] data = new byte[]
				{
					0,
					168
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "SVU-AS")
			{
				byte[] data = new byte[]
				{
					0,
					172
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "XPR-50")
			{
				byte[] data = new byte[]
				{
					0,
					180
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "DSR 50")
			{
				byte[] data = new byte[]
				{
					0,
					176
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "M1216")
			{
				byte[] data = new byte[]
				{
					0,
					192
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "R870 MCS")
			{
				byte[] data = new byte[]
				{
					0,
					188
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "S12")
			{
				byte[] data = new byte[]
				{
					0,
					196
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "KSG")
			{
				byte[] data = new byte[]
				{
					0,
					200
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "Assault Shield")
			{
				byte[] data = new byte[]
				{
					0,
					228
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
			if (this.comboBox_0.Text == "Fake War Machine")
			{
				byte[] data = new byte[]
				{
					0,
					244
				};
				this.xrpc_0.SetMemory(2218080946U, data);
			}
		}

		
		private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_1.Text == "Lightweight")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					148
				});
			}
			if (this.comboBox_1.Text == "Hardline")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					151
				});
			}
			if (this.comboBox_1.Text == "Blind Eye")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					150
				});
			}
			if (this.comboBox_1.Text == "Flak Jacket")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					149
				});
			}
			if (this.comboBox_1.Text == "Ghost")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					152
				});
			}
			if (this.comboBox_1.Text == "Toughness")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					157
				});
			}
			if (this.comboBox_1.Text == "Cold Blooded")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					155
				});
			}
			if (this.comboBox_1.Text == "Fast Hands")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					156
				});
			}
			if (this.comboBox_1.Text == "Hard Wired")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					153
				});
			}
			if (this.comboBox_1.Text == "Scavenger")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					154
				});
			}
			if (this.comboBox_1.Text == "Dexterity")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					158
				});
			}
			if (this.comboBox_1.Text == "Extreme Conditioning")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					161
				});
			}
			if (this.comboBox_1.Text == "Engineer")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					159
				});
			}
			if (this.comboBox_1.Text == "Tactical Mask")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					162
				});
			}
			if (this.comboBox_1.Text == "Dead Silence")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					160
				});
			}
			if (this.comboBox_1.Text == "Awareness")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					163
				});
			}
			if (this.comboBox_1.Text == "K9 Unit")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					219
				});
			}
			if (this.comboBox_1.Text == "Gunship")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					221
				});
			}
			if (this.comboBox_1.Text == "Guardian")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					203
				});
			}
			if (this.comboBox_1.Text == "Lightning Strike")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					205
				});
			}
			if (this.comboBox_1.Text == "A.G.R")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					211
				});
			}
			if (this.comboBox_1.Text == "War Machine")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					209
				});
			}
			if (this.comboBox_1.Text == "Five-Seven Dual")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					9
				});
			}
			if (this.comboBox_1.Text == "Tac-45 Dual")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					8
				});
			}
			if (this.comboBox_1.Text == "Perk 1 Greed")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					181
				});
			}
			if (this.comboBox_1.Text == "Perk 2 Greed")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					182
				});
			}
			if (this.comboBox_1.Text == "Perk 3 Greed")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					183
				});
			}
			if (this.comboBox_1.Text == "Danger Close")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					184
				});
			}
			if (this.comboBox_1.Text == "Tactician")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					185
				});
			}
			if (this.comboBox_1.Text == "Overkill")
			{
				this.xrpc_0.SetMemory(2218080975U, new byte[]
				{
					180
				});
			}
		}

		
		private void comboBox_10_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_10.Text == "Dual Wield Wildcards")
			{
				this.xrpc_0.SetMemory(2218080989U, new byte[]
				{
					1,
					2
				});
				this.xrpc_0.SetMemory(2218080990U, new byte[]
				{
					2,
					2
				});
				this.xrpc_0.SetMemory(2218080991U, new byte[]
				{
					2,
					2
				});
			}
		}

		
		private void comboBox_2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_2.Text == "Lightweight")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					148
				});
			}
			if (this.comboBox_2.Text == "Hardline")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					151
				});
			}
			if (this.comboBox_2.Text == "Blind Eye")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					150
				});
			}
			if (this.comboBox_2.Text == "Flak Jacket")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					149
				});
			}
			if (this.comboBox_2.Text == "Ghost")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					152
				});
			}
			if (this.comboBox_2.Text == "Toughness")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					157
				});
			}
			if (this.comboBox_2.Text == "Cold Blooded")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					155
				});
			}
			if (this.comboBox_2.Text == "Fast Hands")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					156
				});
			}
			if (this.comboBox_2.Text == "Hard Wired")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					153
				});
			}
			if (this.comboBox_2.Text == "Scavenger")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					154
				});
			}
			if (this.comboBox_2.Text == "Dexterity")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					158
				});
			}
			if (this.comboBox_2.Text == "Extreme Conditioning")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					161
				});
			}
			if (this.comboBox_2.Text == "Engineer")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					159
				});
			}
			if (this.comboBox_2.Text == "Tactical Mask")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					162
				});
			}
			if (this.comboBox_2.Text == "Dead Silence")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					160
				});
			}
			if (this.comboBox_2.Text == "Awareness")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					163
				});
			}
			if (this.comboBox_2.Text == "K9 Unit")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					219
				});
			}
			if (this.comboBox_2.Text == "Gunship")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					221
				});
			}
			if (this.comboBox_2.Text == "Guardian")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					203
				});
			}
			if (this.comboBox_2.Text == "Lightning Strike")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					205
				});
			}
			if (this.comboBox_2.Text == "A.G.R")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					211
				});
			}
			if (this.comboBox_2.Text == "War Machine")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					209
				});
			}
			if (this.comboBox_2.Text == "Five-Seven Dual")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					9
				});
			}
			if (this.comboBox_2.Text == "Tac-45 Dual")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					8
				});
			}
			if (this.comboBox_2.Text == "Perk 1 Greed")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					181
				});
			}
			if (this.comboBox_2.Text == "Perk 2 Greed")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					182
				});
			}
			if (this.comboBox_2.Text == "Perk 3 Greed")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					183
				});
			}
			if (this.comboBox_2.Text == "Danger Close")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					184
				});
			}
			if (this.comboBox_2.Text == "Tactician")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					185
				});
			}
			if (this.comboBox_2.Text == "Overkill")
			{
				this.xrpc_0.SetMemory(2218080977U, new byte[]
				{
					180
				});
			}
		}

		
		private void comboBox_4_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_4.Text == "Lightweight")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					148
				});
			}
			if (this.comboBox_4.Text == "Hardline")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					151
				});
			}
			if (this.comboBox_4.Text == "Blind Eye")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					150
				});
			}
			if (this.comboBox_4.Text == "Flak Jacket")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					149
				});
			}
			if (this.comboBox_4.Text == "Ghost")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					152
				});
			}
			if (this.comboBox_4.Text == "Toughness")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					157
				});
			}
			if (this.comboBox_4.Text == "Cold Blooded")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					155
				});
			}
			if (this.comboBox_4.Text == "Fast Hands")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					156
				});
			}
			if (this.comboBox_4.Text == "Hard Wired")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					153
				});
			}
			if (this.comboBox_4.Text == "Scavenger")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					154
				});
			}
			if (this.comboBox_4.Text == "Dexterity")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					158
				});
			}
			if (this.comboBox_4.Text == "Extreme Conditioning")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					161
				});
			}
			if (this.comboBox_4.Text == "Engineer")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					159
				});
			}
			if (this.comboBox_4.Text == "Tactical Mask")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					162
				});
			}
			if (this.comboBox_4.Text == "Dead Silence")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					160
				});
			}
			if (this.comboBox_4.Text == "Awareness")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					163
				});
			}
			if (this.comboBox_4.Text == "K9 Unit")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					219
				});
			}
			if (this.comboBox_4.Text == "Gunship")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					221
				});
			}
			if (this.comboBox_4.Text == "Guardian")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					203
				});
			}
			if (this.comboBox_4.Text == "Lightning Strike")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					205
				});
			}
			if (this.comboBox_4.Text == "A.G.R")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					211
				});
			}
			if (this.comboBox_4.Text == "War Machine")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					209
				});
			}
			if (this.comboBox_4.Text == "Five-Seven Dual")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					9
				});
			}
			if (this.comboBox_4.Text == "Tac-45 Dual")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					8
				});
			}
			if (this.comboBox_4.Text == "Perk 1 Greed")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					181
				});
			}
			if (this.comboBox_4.Text == "Perk 2 Greed")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					182
				});
			}
			if (this.comboBox_4.Text == "Perk 3 Greed")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					183
				});
			}
			if (this.comboBox_4.Text == "Danger Close")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					184
				});
			}
			if (this.comboBox_4.Text == "Tactician")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					185
				});
			}
			if (this.comboBox_4.Text == "Overkill")
			{
				this.xrpc_0.SetMemory(2218080979U, new byte[]
				{
					180
				});
			}
		}

		
		private void comboBox_5_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_5.Text == "Lightweight")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					148
				});
			}
			if (this.comboBox_5.Text == "Hardline")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					151
				});
			}
			if (this.comboBox_5.Text == "Blind Eye")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					150
				});
			}
			if (this.comboBox_5.Text == "Flak Jacket")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					149
				});
			}
			if (this.comboBox_5.Text == "Ghost")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					152
				});
			}
			if (this.comboBox_5.Text == "Toughness")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					157
				});
			}
			if (this.comboBox_5.Text == "Cold Blooded")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					155
				});
			}
			if (this.comboBox_5.Text == "Fast Hands")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					156
				});
			}
			if (this.comboBox_5.Text == "Hard Wired")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					153
				});
			}
			if (this.comboBox_5.Text == "Scavenger")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					154
				});
			}
			if (this.comboBox_5.Text == "Dexterity")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					158
				});
			}
			if (this.comboBox_5.Text == "Extreme Conditioning")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					161
				});
			}
			if (this.comboBox_5.Text == "Engineer")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					159
				});
			}
			if (this.comboBox_5.Text == "Tactical Mask")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					162
				});
			}
			if (this.comboBox_5.Text == "Dead Silence")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					160
				});
			}
			if (this.comboBox_5.Text == "Awareness")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					163
				});
			}
			if (this.comboBox_5.Text == "K9 Unit")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					219
				});
			}
			if (this.comboBox_5.Text == "Gunship")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					221
				});
			}
			if (this.comboBox_5.Text == "Guardian")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					203
				});
			}
			if (this.comboBox_5.Text == "Lightning Strike")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					205
				});
			}
			if (this.comboBox_5.Text == "A.G.R")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					211
				});
			}
			if (this.comboBox_5.Text == "War Machine")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					209
				});
			}
			if (this.comboBox_5.Text == "Five-Seven Dual")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					9
				});
			}
			if (this.comboBox_5.Text == "Tac-45 Dual")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					8
				});
			}
			if (this.comboBox_5.Text == "Perk 1 Greed")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					181
				});
			}
			if (this.comboBox_5.Text == "Perk 2 Greed")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					182
				});
			}
			if (this.comboBox_5.Text == "Perk 3 Greed")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					183
				});
			}
			if (this.comboBox_5.Text == "Danger Close")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					184
				});
			}
			if (this.comboBox_5.Text == "Tactician")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					185
				});
			}
			if (this.comboBox_5.Text == "Overkill")
			{
				this.xrpc_0.SetMemory(2218080980U, new byte[]
				{
					180
				});
			}
		}

		
		private void comboBox_6_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_6.Text == "B23R Dual Wield")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					22
				});
			}
			if (this.comboBox_6.Text == "KAP-40 Dual Wield")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					14
				});
			}
			if (this.comboBox_6.Text == "Five-Seven Dual Wield")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					19
				});
			}
			if (this.comboBox_6.Text == "Tac-45 Dual Wield")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					17
				});
			}
			if (this.comboBox_6.Text == "Executioner Dual Wield")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					20
				});
			}
			if (this.comboBox_6.Text == "MP7")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					26
				});
			}
			if (this.comboBox_6.Text == "Skorpion EVO")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					28
				});
			}
			if (this.comboBox_6.Text == "Chicom CQB")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					32
				});
			}
			if (this.comboBox_6.Text == "MSMC")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					34
				});
			}
			if (this.comboBox_6.Text == "Vector K10")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					36
				});
			}
			if (this.comboBox_6.Text == "M8A1")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					48
				});
			}
			if (this.comboBox_6.Text == "SCAR-H")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					50
				});
			}
			if (this.comboBox_6.Text == "AN-94")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					52
				});
			}
			if (this.comboBox_6.Text == "Type 25")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					56
				});
			}
			if (this.comboBox_6.Text == "FAL OSW")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					58
				});
			}
			if (this.comboBox_6.Text == "MTAR")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					64
				});
			}
			if (this.comboBox_6.Text == "MK 48")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					72
				});
			}
			if (this.comboBox_6.Text == "QBB LSW")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					74
				});
			}
			if (this.comboBox_6.Text == "LSAT")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					76
				});
			}
			if (this.comboBox_6.Text == "SMR")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					60
				});
			}
			if (this.comboBox_6.Text == "HAMR")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					78
				});
			}
			if (this.comboBox_6.Text == "PDW-57")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					30
				});
			}
			if (this.comboBox_6.Text == "Peacekeeper")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					38
				});
			}
			if (this.comboBox_6.Text == "SWAT-556")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					54
				});
			}
			if (this.comboBox_6.Text == "M27")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					62
				});
			}
			if (this.comboBox_6.Text == "Ballista")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					84
				});
			}
			if (this.comboBox_6.Text == "SVU-AS")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					86
				});
			}
			if (this.comboBox_6.Text == "XPR-50")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					90
				});
			}
			if (this.comboBox_6.Text == "DSR 50")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					88
				});
			}
			if (this.comboBox_6.Text == "M1216")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					96
				});
			}
			if (this.comboBox_6.Text == "R870 MCS")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					94
				});
			}
			if (this.comboBox_6.Text == "S12")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					98
				});
			}
			if (this.comboBox_6.Text == "KSG")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					100
				});
			}
			if (this.comboBox_6.Text == "Assault Shield")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					114
				});
			}
			if (this.comboBox_6.Text == "Fake War Machine")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					122
				});
			}
			if (this.comboBox_6.Text == "B23R")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					8
				});
			}
			if (this.comboBox_6.Text == "KAP-40")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					4
				});
			}
			if (this.comboBox_6.Text == "Five-Seven")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					12
				});
			}
			if (this.comboBox_6.Text == "Tac-45")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					6
				});
			}
			if (this.comboBox_6.Text == "Executioner")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					10
				});
			}
			if (this.comboBox_6.Text == "RPG")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					110
				});
			}
			if (this.comboBox_6.Text == "SMAW")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					106
				});
			}
			if (this.comboBox_6.Text == "FHJ-18 AA")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					108
				});
			}
			if (this.comboBox_6.Text == "Crossbow")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					116
				});
			}
			if (this.comboBox_6.Text == "Ballistic Knife")
			{
				this.xrpc_0.SetMemory(2218080961U, new byte[]
				{
					118
				});
			}
		}

		
		private void comboBox_7_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_7.Text == "MP7")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					13
				});
			}
			if (this.comboBox_7.Text == "Skorpion EVO")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					14
				});
			}
			if (this.comboBox_7.Text == "PDW-57")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					15
				});
			}
			if (this.comboBox_7.Text == "Chicom CQB")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					16
				});
			}
			if (this.comboBox_7.Text == "MSMC")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					17
				});
			}
			if (this.comboBox_7.Text == "Peacekeeper")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					19
				});
			}
			if (this.comboBox_7.Text == "Vector K10")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					18
				});
			}
			if (this.comboBox_7.Text == "M8A1")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					24
				});
			}
			if (this.comboBox_7.Text == "SCAR-H")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					25
				});
			}
			if (this.comboBox_7.Text == "AN-94")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					26
				});
			}
			if (this.comboBox_7.Text == "SWAT-556")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					27
				});
			}
			if (this.comboBox_7.Text == "Type 25")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					28
				});
			}
			if (this.comboBox_7.Text == "FAL OSW")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					29
				});
			}
			if (this.comboBox_7.Text == "SMR")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					30
				});
			}
			if (this.comboBox_7.Text == "M27")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					31
				});
			}
			if (this.comboBox_7.Text == "MTAR")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					32
				});
			}
			if (this.comboBox_7.Text == "MK 48")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					36
				});
			}
			if (this.comboBox_7.Text == "QBB LSW")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					37
				});
			}
			if (this.comboBox_7.Text == "LSAT")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					38
				});
			}
			if (this.comboBox_7.Text == "HAMR")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					39
				});
			}
			if (this.comboBox_7.Text == "Ballista")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					42
				});
			}
			if (this.comboBox_7.Text == "SVU-AS")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					43
				});
			}
			if (this.comboBox_7.Text == "DSR 50")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					44
				});
			}
			if (this.comboBox_7.Text == "XPR-50")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					45
				});
			}
			if (this.comboBox_7.Text == "R870 MCS")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					47
				});
			}
			if (this.comboBox_7.Text == "M126")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					48
				});
			}
			if (this.comboBox_7.Text == "S12")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					49
				});
			}
			if (this.comboBox_7.Text == "KSG")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					50
				});
			}
			if (this.comboBox_7.Text == "SMAW")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					53
				});
			}
			if (this.comboBox_7.Text == "FHJ-18 AA")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					54
				});
			}
			if (this.comboBox_7.Text == "RPG")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					55
				});
			}
			if (this.comboBox_7.Text == "Assault Shield")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					57
				});
			}
			if (this.comboBox_7.Text == "Crossbow")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					58
				});
			}
			if (this.comboBox_7.Text == "Ballistic Knife")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					59
				});
			}
			if (this.comboBox_7.Text == "Grenade")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					63
				});
			}
			if (this.comboBox_7.Text == "KAP-40")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					2
				});
			}
			if (this.comboBox_7.Text == "Tac-45")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					3
				});
			}
			if (this.comboBox_7.Text == "B23R")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					4
				});
			}
			if (this.comboBox_7.Text == "Executioner")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					5
				});
			}
			if (this.comboBox_7.Text == "Five-Seven")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					6
				});
			}
			if (this.comboBox_7.Text == "KAP-40 Dual Wield")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					7
				});
			}
			if (this.comboBox_7.Text == "Tac-45 Dual Wield")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					8
				});
			}
			if (this.comboBox_7.Text == "Five-Seven Dual Wield")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					9
				});
			}
			if (this.comboBox_7.Text == "Executioner Dual Wield")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					10
				});
			}
			if (this.comboBox_7.Text == "B23R Dual Wield")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					11
				});
			}
			if (this.comboBox_7.Text == "Combat Axe")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					64
				});
			}
			if (this.comboBox_7.Text == "Semtex")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					65
				});
			}
			if (this.comboBox_7.Text == "C4")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					66
				});
			}
			if (this.comboBox_7.Text == "Bouncing Betty")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					67
				});
			}
			if (this.comboBox_7.Text == "Claymore")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					68
				});
			}
			if (this.comboBox_7.Text == "Smoke Grenade")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					70
				});
			}
			if (this.comboBox_7.Text == "Concussion")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					71
				});
			}
			if (this.comboBox_7.Text == "EMP Grenade")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					72
				});
			}
			if (this.comboBox_7.Text == "Sensor Grenade")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					73
				});
			}
			if (this.comboBox_7.Text == "Flashbang")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					74
				});
			}
			if (this.comboBox_7.Text == "Shockcharge")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					75
				});
			}
			if (this.comboBox_7.Text == "Black Hat")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					76
				});
			}
			if (this.comboBox_7.Text == "Tactical Insertion")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					77
				});
			}
			if (this.comboBox_7.Text == "Trophy System")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					78
				});
			}
			if (this.comboBox_7.Text == "WEAPON_DESTRUCTIBLE_CAR")
			{
				this.xrpc_0.SetMemory(2218080981U, new byte[]
				{
					193
				});
			}
		}

		
		private void comboBox_8_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_8.Text == "MP7")
			{
				byte[] data = new byte[]
				{
					0,
					104
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "PDW-57")
			{
				byte[] data = new byte[]
				{
					0,
					120
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Vector K10")
			{
				byte[] data = new byte[]
				{
					0,
					144
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "MSMC")
			{
				byte[] data = new byte[]
				{
					0,
					136
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Chicom CQB")
			{
				byte[] data = new byte[]
				{
					0,
					128
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Skorpion EVO")
			{
				byte[] data = new byte[]
				{
					0,
					112
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Peacekeeper")
			{
				byte[] data = new byte[]
				{
					0,
					152
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "MTAR")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					1,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "Type 25")
			{
				byte[] data = new byte[]
				{
					0,
					225,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "SWAT-556")
			{
				byte[] data = new byte[]
				{
					0,
					216,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "FAL OSW")
			{
				byte[] data = new byte[]
				{
					0,
					232,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "M27")
			{
				byte[] data = new byte[]
				{
					0,
					248,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "SCAR-H")
			{
				byte[] data = new byte[]
				{
					0,
					200,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "SMR")
			{
				byte[] data = new byte[]
				{
					0,
					241,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "M8A1")
			{
				byte[] data = new byte[]
				{
					0,
					193,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "AN-94")
			{
				byte[] data = new byte[]
				{
					0,
					209,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "R870 MCS")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					120,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "S12")
			{
				byte[] data = new byte[]
				{
					0,
					136,
					17
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "KSG")
			{
				byte[] data = new byte[]
				{
					0,
					148,
					17
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "M1216")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					135,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "MK 48")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					32,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "QBB LSW")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					41,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "LSAT")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					48,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "HAMR")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					56,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "SVU-AS")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					89,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "DSR 50")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					103,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "Ballista")
			{
				byte[] data = new byte[]
				{
					0,
					84,
					17
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "XPR-50")
			{
				byte[] data = new byte[]
				{
					0,
					104,
					17
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Assault Shield")
			{
				byte[] data = new byte[]
				{
					0,
					204,
					17
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Five-Seven")
			{
				byte[] data = new byte[]
				{
					0,
					48,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Tac-45")
			{
				byte[] data = new byte[]
				{
					0,
					24,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "B23R")
			{
				byte[] data = new byte[]
				{
					0,
					32,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Executioner")
			{
				byte[] data = new byte[]
				{
					0,
					40,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "KAP-40")
			{
				byte[] data = new byte[]
				{
					0,
					16,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Five-Seven Dual Wield")
			{
				byte[] data = new byte[]
				{
					0,
					72,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Tac-45 Dual Wield")
			{
				byte[] data = new byte[]
				{
					0,
					64,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "B23R Dual Wield")
			{
				byte[] data = new byte[]
				{
					0,
					88,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Executioner Dual Wield")
			{
				byte[] data = new byte[]
				{
					0,
					80,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "KAP-40 Dual Wield")
			{
				byte[] data = new byte[]
				{
					0,
					56,
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "SMAW")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					168,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "FHJ-18 AA")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					177,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "RPG")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					184,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "Ballistic Knife")
			{
				this.xrpc_0.SetMemory(2218080982U, new byte[]
				{
					0,
					223,
					17,
					88
				});
			}
			if (this.comboBox_8.Text == "Crossbow")
			{
				byte[] data = new byte[]
				{
					0,
					209,
					17
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Combat Axe")
			{
				byte[] data = new byte[]
				{
					0,
					1
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Semtex")
			{
				byte[] data = new byte[]
				{
					0,
					8
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "C4")
			{
				byte[] data = new byte[]
				{
					0,
					16
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Bouncing Betty")
			{
				byte[] data = new byte[]
				{
					0,
					24
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Claymore")
			{
				byte[] data = new byte[]
				{
					0,
					32
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Grenade")
			{
				byte[] data = new byte[]
				{
					0,
					250,
					17
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Smoke Grenade")
			{
				byte[] data = new byte[]
				{
					0,
					48
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Concussion")
			{
				byte[] data = new byte[]
				{
					0,
					56
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "EMP Grenade")
			{
				byte[] data = new byte[]
				{
					0,
					64
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Sensor Grenade")
			{
				byte[] data = new byte[]
				{
					0,
					72
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Flashbang")
			{
				byte[] data = new byte[]
				{
					0,
					80
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Black Hat")
			{
				byte[] data = new byte[]
				{
					0,
					96
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Trophy System")
			{
				byte[] data = new byte[]
				{
					0,
					112
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Shock Charge")
			{
				byte[] data = new byte[]
				{
					0,
					88
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Tactical Insertion")
			{
				byte[] data = new byte[]
				{
					0,
					104
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
		}

		
		private void comboBox_9_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_9.Text == "Lightweight")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					148
				});
			}
			if (this.comboBox_9.Text == "Hardline")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					151
				});
			}
			if (this.comboBox_9.Text == "Blind Eye")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					150
				});
			}
			if (this.comboBox_9.Text == "Flak Jacket")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					149
				});
			}
			if (this.comboBox_9.Text == "Ghost")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					152
				});
			}
			if (this.comboBox_9.Text == "Toughness")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					157
				});
			}
			if (this.comboBox_9.Text == "Cold Blooded")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					155
				});
			}
			if (this.comboBox_9.Text == "Fast Hands")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					156
				});
			}
			if (this.comboBox_9.Text == "Hard Wired")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					153
				});
			}
			if (this.comboBox_9.Text == "Scavenger")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					154
				});
			}
			if (this.comboBox_9.Text == "Dexterity")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					158
				});
			}
			if (this.comboBox_9.Text == "Extreme Conditioning")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					161
				});
			}
			if (this.comboBox_9.Text == "Engineer")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					159
				});
			}
			if (this.comboBox_9.Text == "Tactical Mask")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					162
				});
			}
			if (this.comboBox_9.Text == "Dead Silence")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					160
				});
			}
			if (this.comboBox_9.Text == "Awareness")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					163
				});
			}
			if (this.comboBox_9.Text == "K9 Unit")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					219
				});
			}
			if (this.comboBox_9.Text == "Gunship")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					221
				});
			}
			if (this.comboBox_9.Text == "Guardian")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					203
				});
			}
			if (this.comboBox_9.Text == "Lightning Strike")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					205
				});
			}
			if (this.comboBox_9.Text == "A.G.R")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					211
				});
			}
			if (this.comboBox_9.Text == "War Machine")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					209
				});
			}
			if (this.comboBox_9.Text == "Five-Seven Dual")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					9
				});
			}
			if (this.comboBox_9.Text == "Tac-45 Dual")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					8
				});
			}
			if (this.comboBox_9.Text == "Perk 1 Greed")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					181
				});
			}
			if (this.comboBox_9.Text == "Perk 2 Greed")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					182
				});
			}
			if (this.comboBox_9.Text == "Perk 3 Greed")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					183
				});
			}
			if (this.comboBox_9.Text == "Danger Close")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					184
				});
			}
			if (this.comboBox_9.Text == "Tactician")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					185
				});
			}
			if (this.comboBox_9.Text == "Overkill")
			{
				this.xrpc_0.SetMemory(2218080976U, new byte[]
				{
					180
				});
			}
		}

		
		private void label_0_Click(object sender, EventArgs e)
		{
		}

		
		private void comboBox_3_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		
		private void tabPage_0_Click(object sender, EventArgs e)
		{
		}

		
		private void method_0(object sender, EventArgs e)
		{
			this.xrpc_0.SetMemory(2218081535U, new byte[]
			{
				26
			});
		}

		
		private void method_1(object sender, EventArgs e)
		{
			this.xrpc_0.SetMemory(2218081533U, new byte[]
			{
				26
			});
		}

		
		private void method_10(object sender, EventArgs e)
		{
		}

		
		private void method_11(object sender, EventArgs e)
		{
		}

		
		private void method_15(object sender, EventArgs e)
		{
			MessageBox.Show("Set 2 Tacticals to make the lethals show up");
		}

		
		private void method_16(object sender, EventArgs e)
		{
			MessageBox.Show("You must have your tacticals empty to get this to work. It does not stick. This is a watered down version of XBOX360lSBEST's 4 Gun Classes avalible in his paid tool. Used with permission.");
		}

		
		private void method_17(object sender, EventArgs e)
		{
			MessageBox.Show("Anything that's NOT a checkerboard sticks to your account", "What Sticks To Accounts?");
			MessageBox.Show("Primary weapons on the Secondary slot only stick if you have Overkill on", "What Sticks To Accounts?");
			MessageBox.Show("Perks will stick but you will need to use the perk greed wildcards (When Needed)", "What Sticks To Accounts?");
			MessageBox.Show("Anything that is a checkerboard resets after one game", "What Sticks To Accounts?");
			MessageBox.Show("Infanite Class Items resets after you restart the game", "What Sticks To Accounts?");
			MessageBox.Show("All The Preset Classes Stick", "What Sticks To Accounts?");
		}

		
		private void method_2(object sender, EventArgs e)
		{
			MessageBox.Show("LOLZ");
		}

		
		private void method_3(object sender, EventArgs e)
		{
			this.xrpc_0.SetMemory(2218080975U, new byte[]
			{
				148,
				149,
				150,
				151,
				152
			});
		}

		
		private void method_4(object sender, EventArgs e)
		{
			this.xrpc_0.SetMemory(2218080975U, new byte[]
			{
				154,
				155,
				156,
				157,
				153
			});
		}

		
		private void method_5(object sender, EventArgs e)
		{
			this.xrpc_0.SetMemory(2218080975U, new byte[]
			{
				160,
				161,
				162,
				163,
				158,
				159
			});
		}

		
		private void method_6(object sender, EventArgs e)
		{
			if (this.comboBox_8.Text == "Tac-45")
			{
				byte[] data = new byte[]
				{
					0,
					26
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "B23R")
			{
				byte[] data = new byte[]
				{
					0,
					18
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
			if (this.comboBox_8.Text == "Kap-40")
			{
				byte[] data = new byte[]
				{
					0,
					33
				};
				this.xrpc_0.SetMemory(2218080982U, data);
			}
		}

		
		private void method_7(object sender, EventArgs e)
		{
			this.xrpc_0.SetMemory(2218080975U, new byte[]
			{
				182,
				183,
				184,
				181,
				185,
				180
			});
		}

		
		private void button1_Click(object sender, EventArgs e)
		{
		}

		
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		
		private void InitializeComponent()
		{
			this.groupBox_0 = new GroupBox();
			this.comboBox_10 = new ComboBox();
			this.label_0 = new Label();
			this.comboBox_5 = new ComboBox();
			this.comboBox_4 = new ComboBox();
			this.comboBox_3 = new ComboBox();
			this.comboBox_2 = new ComboBox();
			this.comboBox_9 = new ComboBox();
			this.comboBox_8 = new ComboBox();
			this.comboBox_1 = new ComboBox();
			this.comboBox_7 = new ComboBox();
			this.comboBox_6 = new ComboBox();
			this.comboBox_0 = new ComboBox();
			this.tabPage_0 = new TabPage();
			this.tabControl_0 = new TabControl();
			this.groupBox_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			this.tabControl_0.SuspendLayout();
			base.SuspendLayout();
			this.groupBox_0.Controls.Add(this.comboBox_10);
			this.groupBox_0.Controls.Add(this.label_0);
			this.groupBox_0.Controls.Add(this.comboBox_5);
			this.groupBox_0.Controls.Add(this.comboBox_4);
			this.groupBox_0.Controls.Add(this.comboBox_3);
			this.groupBox_0.Controls.Add(this.comboBox_2);
			this.groupBox_0.Controls.Add(this.comboBox_9);
			this.groupBox_0.Controls.Add(this.comboBox_8);
			this.groupBox_0.Controls.Add(this.comboBox_1);
			this.groupBox_0.Controls.Add(this.comboBox_7);
			this.groupBox_0.Controls.Add(this.comboBox_6);
			this.groupBox_0.Controls.Add(this.comboBox_0);
			this.groupBox_0.Location = new Point(13, 11);
			this.groupBox_0.Name = "groupBox_0";
			this.groupBox_0.Size = new Size(281, 248);
			this.groupBox_0.TabIndex = 0;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = "Public Match (Class 3)";
			this.comboBox_10.FormattingEnabled = true;
			this.comboBox_10.Items.AddRange(new object[]
			{
				"Dual Wield Wildcards"
			});
			this.comboBox_10.Location = new Point(19, 208);
			this.comboBox_10.Name = "comboBox_10";
			this.comboBox_10.Size = new Size(248, 21);
			this.comboBox_10.TabIndex = 8;
			this.comboBox_10.Text = "Wildcards";
			this.comboBox_10.SelectedIndexChanged += this.comboBox_10_SelectedIndexChanged;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(164, 0);
			this.label_0.Name = "label_0";
			this.label_0.Size = new Size(104, 13);
			this.label_0.TabIndex = 1;
			this.label_0.Text = "Awaiting Connection";
			this.label_0.Click += this.label_0_Click;
			this.comboBox_5.FormattingEnabled = true;
			this.comboBox_5.Items.AddRange(new object[]
			{
				"----Perk 1----",
				"",
				"Lightweight",
				"Hardline",
				"Blind Eye",
				"Flak Jacket",
				"Ghost",
				"----Perk 2----",
				"",
				"Toughness",
				"Cold Blooded",
				"Fast Hands",
				"Hard Wired",
				"Scavenger",
				"",
				"----Perk 3----",
				"",
				"Dexterity",
				"Extreme Conditioning",
				"Engineer",
				"Tactical Mask",
				"Dead Silence",
				"Awareness",
				"",
				"----Scorestreaks (For Show)----",
				"",
				"K9 Unit",
				"Gunship",
				"Guardian",
				"Lightning Strike",
				"A.G.R",
				"War Machine",
				"",
				"----Dual Wield Guns----",
				"",
				"Five-Seven Dual",
				"Tac-45 Dual",
				"",
				"----Perks (For Show)----",
				"Perk 1 Greed",
				"Perk 2 Greed",
				"Perk 3 Greed",
				"Tactician",
				"Danger Close",
				"Overkill"
			});
			this.comboBox_5.Location = new Point(146, 181);
			this.comboBox_5.Name = "comboBox_5";
			this.comboBox_5.Size = new Size(121, 21);
			this.comboBox_5.TabIndex = 7;
			this.comboBox_5.Text = "Perk 3 Greed";
			this.comboBox_5.SelectedIndexChanged += this.comboBox_5_SelectedIndexChanged;
			this.comboBox_4.FormattingEnabled = true;
			this.comboBox_4.Items.AddRange(new object[]
			{
				"----Perk 1----",
				"",
				"Lightweight",
				"Hardline",
				"Blind Eye",
				"Flak Jacket",
				"Ghost",
				"----Perk 2----",
				"",
				"Toughness",
				"Cold Blooded",
				"Fast Hands",
				"Hard Wired",
				"Scavenger",
				"",
				"----Perk 3----",
				"",
				"Dexterity",
				"Extreme Conditioning",
				"Engineer",
				"Tactical Mask",
				"Dead Silence",
				"Awareness",
				"",
				"----Scorestreaks (For Show)----",
				"",
				"K9 Unit",
				"Gunship",
				"Guardian",
				"Lightning Strike",
				"A.G.R",
				"War Machine",
				"",
				"----Dual Wield Guns----",
				"",
				"Five-Seven Dual",
				"Tac-45 Dual",
				"",
				"----Perks (For Show)----",
				"Perk 1 Greed",
				"Perk 2 Greed",
				"Perk 3 Greed",
				"Tactician",
				"Danger Close",
				"Overkill"
			});
			this.comboBox_4.Location = new Point(146, 154);
			this.comboBox_4.Name = "comboBox_4";
			this.comboBox_4.Size = new Size(121, 21);
			this.comboBox_4.TabIndex = 6;
			this.comboBox_4.Text = "Perk 2 Greed";
			this.comboBox_4.SelectedIndexChanged += this.comboBox_4_SelectedIndexChanged;
			this.comboBox_3.FormattingEnabled = true;
			this.comboBox_3.Items.AddRange(new object[]
			{
				"----Perk 1----",
				"",
				"Lightweight",
				"Hardline",
				"Blind Eye",
				"Flak Jacket",
				"Ghost",
				"----Perk 2----",
				"",
				"Toughness",
				"Cold Blooded",
				"Fast Hands",
				"Hard Wired",
				"Scavenger",
				"",
				"----Perk 3----",
				"",
				"Dexterity",
				"Extreme Conditioning",
				"Engineer",
				"Tactical Mask",
				"Dead Silence",
				"Awareness",
				"",
				"----Scorestreaks (For Show)----",
				"",
				"K9 Unit",
				"Gunship",
				"Guardian",
				"Lightning Strike",
				"A.G.R",
				"War Machine",
				"",
				"----Dual Wield Guns----",
				"",
				"Five-Seven Dual",
				"Tac-45 Dual",
				"",
				"----Perks (For Show)----",
				"Perk 1 Greed",
				"Perk 2 Greed",
				"Perk 3 Greed",
				"Tactician",
				"Danger Close",
				"Overkill"
			});
			this.comboBox_3.Location = new Point(147, 127);
			this.comboBox_3.Name = "comboBox_3";
			this.comboBox_3.Size = new Size(121, 21);
			this.comboBox_3.TabIndex = 4;
			this.comboBox_3.Text = "Perk 1 Greed";
			this.comboBox_3.SelectedIndexChanged += this.comboBox_3_SelectedIndexChanged;
			this.comboBox_2.FormattingEnabled = true;
			this.comboBox_2.Items.AddRange(new object[]
			{
				"----Perk 1----",
				"",
				"Lightweight",
				"Hardline",
				"Blind Eye",
				"Flak Jacket",
				"Ghost",
				"----Perk 2----",
				"",
				"Toughness",
				"Cold Blooded",
				"Fast Hands",
				"Hard Wired",
				"Scavenger",
				"",
				"----Perk 3----",
				"",
				"Dexterity",
				"Extreme Conditioning",
				"Engineer",
				"Tactical Mask",
				"Dead Silence",
				"Awareness",
				"",
				"----Scorestreaks (For Show)----",
				"",
				"K9 Unit",
				"Gunship",
				"Guardian",
				"Lightning Strike",
				"A.G.R",
				"War Machine",
				"",
				"----Dual Wield Guns----",
				"",
				"Five-Seven Dual",
				"Tac-45 Dual",
				"",
				"----Perks (For Show)----",
				"Perk 1 Greed",
				"Perk 2 Greed",
				"Perk 3 Greed",
				"Tactician",
				"Danger Close",
				"Overkill"
			});
			this.comboBox_2.Location = new Point(19, 181);
			this.comboBox_2.Name = "comboBox_2";
			this.comboBox_2.Size = new Size(121, 21);
			this.comboBox_2.TabIndex = 3;
			this.comboBox_2.Text = "Perk 3";
			this.comboBox_2.SelectedIndexChanged += this.comboBox_2_SelectedIndexChanged;
			this.comboBox_9.FormattingEnabled = true;
			this.comboBox_9.Items.AddRange(new object[]
			{
				"----Perk 1----",
				"",
				"Lightweight",
				"Hardline",
				"Blind Eye",
				"Flak Jacket",
				"Ghost",
				"----Perk 2----",
				"",
				"Toughness",
				"Cold Blooded",
				"Fast Hands",
				"Hard Wired",
				"Scavenger",
				"",
				"----Perk 3----",
				"",
				"Dexterity",
				"Extreme Conditioning",
				"Engineer",
				"Tactical Mask",
				"Dead Silence",
				"Awareness",
				"",
				"----Scorestreaks (For Show)----",
				"",
				"K9 Unit",
				"Gunship",
				"Guardian",
				"Lightning Strike",
				"A.G.R",
				"War Machine",
				"",
				"----Dual Wield Guns----",
				"",
				"Five-Seven Dual",
				"Tac-45 Dual",
				"",
				"----Perks (For Show)----",
				"Perk 1 Greed",
				"Perk 2 Greed",
				"Perk 3 Greed",
				"Tactician",
				"Danger Close",
				"Overkill"
			});
			this.comboBox_9.Location = new Point(19, 154);
			this.comboBox_9.Name = "comboBox_9";
			this.comboBox_9.Size = new Size(121, 21);
			this.comboBox_9.TabIndex = 2;
			this.comboBox_9.Text = "Perk 2";
			this.comboBox_9.SelectedIndexChanged += this.comboBox_9_SelectedIndexChanged;
			this.comboBox_8.FormattingEnabled = true;
			this.comboBox_8.Items.AddRange(new object[]
			{
				"For Lethals / Tacticals:",
				"Set two tactical grenades on your class first.",
				"",
				"For Primary / Secondary Weapons:",
				"Clear your tactical slots on your loadou first.",
				"",
				"Sub Machine Guns",
				"",
				"MP7",
				"PDW-57",
				"Vector K10",
				"MSMC",
				"Chicom CQB",
				"Skorpion EVO",
				"Peacekeeper",
				"",
				"Assault Rifles",
				"",
				"MTAR",
				"Type 25",
				"SWAT-556",
				"FAL OSW",
				"M27",
				"SCAR-H",
				"SMR",
				"M8A1",
				"AN-94",
				"",
				"Shotguns",
				"",
				"R870 MCS",
				"S12",
				"KSG",
				"M1216",
				"",
				"Light Machine Guns",
				"",
				"MK 48",
				"QBB LSW",
				"LSAT",
				"HAMR",
				"",
				"Sniper Rifles",
				"",
				"SVU-AS",
				"DSR 50",
				"Ballista",
				"XPR-50",
				"",
				"Shields",
				"Assault Shield",
				"",
				"Pistols",
				"",
				"Five-Seven",
				"Tac-45",
				"B23R",
				"Executioner",
				"KAP-40",
				"Five-Seven Dual Wield",
				"Tac-45 Dual Wield",
				"B23R Dual Wield",
				"Executioner Dual Wield",
				"KAP-40 Dual Wield",
				"",
				"Launchers",
				"",
				"SMAW",
				"FHJ-18 AA",
				"RPG",
				"",
				"Specials",
				"",
				"Crossbow",
				"Ballistic Knife",
				"",
				"Lethal",
				"",
				"Grenade",
				"Semtex",
				"Combat Axe",
				"Bouncing Betty",
				"C4",
				"Claymore",
				"",
				"Tactical",
				"",
				"Concussion",
				"Smoke Grenade",
				"Sensor Grenade",
				"EMP Grenade",
				"Shock Charge",
				"Black Hat",
				"Flashbang",
				"Trophy System",
				"Tactical Insertion"
			});
			this.comboBox_8.Location = new Point(19, 100);
			this.comboBox_8.Name = "comboBox_8";
			this.comboBox_8.Size = new Size(248, 21);
			this.comboBox_8.TabIndex = 2;
			this.comboBox_8.Text = "Tactical";
			this.comboBox_8.SelectedIndexChanged += this.comboBox_8_SelectedIndexChanged;
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Items.AddRange(new object[]
			{
				"----Perk 1----",
				"",
				"Lightweight",
				"Hardline",
				"Blind Eye",
				"Flak Jacket",
				"Ghost",
				"----Perk 2----",
				"",
				"Toughness",
				"Cold Blooded",
				"Fast Hands",
				"Hard Wired",
				"Scavenger",
				"",
				"----Perk 3----",
				"",
				"Dexterity",
				"Extreme Conditioning",
				"Engineer",
				"Tactical Mask",
				"Dead Silence",
				"Awareness",
				"",
				"----Scorestreaks (For Show)----",
				"",
				"K9 Unit",
				"Gunship",
				"Guardian",
				"Lightning Strike",
				"A.G.R",
				"War Machine",
				"",
				"----Dual Wield Guns----",
				"",
				"Five-Seven Dual",
				"Tac-45 Dual",
				"",
				"----Perks (For Show)----",
				"Perk 1 Greed",
				"Perk 2 Greed",
				"Perk 3 Greed",
				"Tactician",
				"Danger Close",
				"Overkill"
			});
			this.comboBox_1.Location = new Point(19, 127);
			this.comboBox_1.Name = "comboBox_1";
			this.comboBox_1.Size = new Size(121, 21);
			this.comboBox_1.TabIndex = 1;
			this.comboBox_1.Text = "Perk 1";
			this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
			this.comboBox_7.FormattingEnabled = true;
			this.comboBox_7.Items.AddRange(new object[]
			{
				"Sub Machine Guns",
				"",
				"MP7",
				"PDW-57",
				"Vector K10",
				"MSMC",
				"Chicom CQB",
				"Skorpion EVO",
				"Peacekeeper",
				"",
				"Assault Rifles",
				"",
				"MTAR",
				"Type 25",
				"SWAT-556",
				"FAL OSW",
				"M27",
				"SCAR-H",
				"SMR",
				"M8A1",
				"AN-94",
				"",
				"Shotguns",
				"",
				"R870 MCS",
				"S12",
				"KSG",
				"M1216",
				"",
				"Light Machine Guns",
				"",
				"MK 48",
				"QBB LSW",
				"LSAT",
				"HAMR",
				"",
				"Sniper Rifles",
				"",
				"SVU-AS",
				"DSR 50",
				"Ballista",
				"XPR-50",
				"",
				"Shields",
				"Assault Shield",
				"",
				"Pistols",
				"",
				"Five-Seven",
				"Tac-45",
				"B23R",
				"Executioner",
				"KAP-40",
				"Five-Seven Dual Wield",
				"Tac-45 Dual Wield",
				"B23R Dual Wield",
				"Executioner Dual Wield",
				"KAP-40 Dual Wield",
				"",
				"Launchers",
				"",
				"SMAW",
				"FHJ-18 AA",
				"RPG",
				"",
				"Specials",
				"",
				"Crossbow",
				"Ballistic Knife",
				"",
				"Lethal",
				"",
				"Grenade",
				"Semtex",
				"Combat Axe",
				"Bouncing Betty",
				"C4",
				"Claymore",
				"WEAPON_DESTRUCTIBLE_CAR",
				"",
				"Tactical",
				"",
				"Concussion",
				"Smoke Grenade",
				"Sensor Grenade",
				"EMP Grenade",
				"Shock Charge",
				"Black Hat",
				"Flashbang",
				"Trophy System",
				"Tactical Insertion"
			});
			this.comboBox_7.Location = new Point(19, 73);
			this.comboBox_7.Name = "comboBox_7";
			this.comboBox_7.Size = new Size(248, 21);
			this.comboBox_7.TabIndex = 2;
			this.comboBox_7.Text = "Lethal";
			this.comboBox_7.SelectedIndexChanged += this.comboBox_7_SelectedIndexChanged;
			this.comboBox_6.FormattingEnabled = true;
			this.comboBox_6.Items.AddRange(new object[]
			{
				"Sub Machine Guns",
				"",
				"MP7",
				"PDW-57",
				"Vector K10",
				"MSMC",
				"Chicom CQB",
				"Skorpion EVO",
				"Peacekeeper",
				"",
				"Assault Rifles",
				"",
				"MTAR",
				"Type 25",
				"SWAT-556",
				"FAL OSW",
				"M27",
				"SCAR-H",
				"SMR",
				"M8A1",
				"AN-94",
				"",
				"Shotguns",
				"",
				"R870 MCS",
				"S12",
				"KSG",
				"M1216",
				"",
				"Light Machine Guns",
				"",
				"MK 48",
				"QBB LSW",
				"LSAT",
				"HAMR",
				"",
				"Sniper Rifles",
				"",
				"SVU-AS",
				"DSR 50",
				"Ballista",
				"XPR-50",
				"",
				"Shields",
				"Assault Shield",
				"",
				"Pistols",
				"",
				"Five-Seven",
				"Tac-45",
				"B23R",
				"Executioner",
				"KAP-40",
				"Five-Seven Dual Wield",
				"Tac-45 Dual Wield",
				"B23R Dual Wield",
				"Executioner Dual Wield",
				"KAP-40 Dual Wield",
				"",
				"Launchers",
				"",
				"SMAW",
				"FHJ-18 AA",
				"RPG",
				"",
				"Specials",
				"",
				"Crossbow",
				"Ballistic Knife",
				"",
				"Misc",
				"",
				"Fake War Machine"
			});
			this.comboBox_6.Location = new Point(19, 46);
			this.comboBox_6.Name = "comboBox_6";
			this.comboBox_6.Size = new Size(248, 21);
			this.comboBox_6.TabIndex = 2;
			this.comboBox_6.Text = "Secondary";
			this.comboBox_6.SelectedIndexChanged += this.comboBox_6_SelectedIndexChanged;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Items.AddRange(new object[]
			{
				"Sub Machine Guns",
				"",
				"MP7",
				"PDW-57",
				"Vector K10",
				"MSMC",
				"Chicom CQB",
				"Skorpion EVO",
				"Peacekeeper",
				"",
				"Assault Rifles",
				"",
				"MTAR",
				"Type 25",
				"SWAT-556",
				"FAL OSW",
				"M27",
				"SCAR-H",
				"SMR",
				"M8A1",
				"AN-94",
				"",
				"Shotguns",
				"",
				"R870 MCS",
				"S12",
				"KSG",
				"M1216",
				"",
				"Light Machine Guns",
				"",
				"MK 48",
				"QBB LSW",
				"LSAT",
				"HAMR",
				"",
				"Sniper Rifles",
				"",
				"SVU-AS",
				"DSR 50",
				"Ballista",
				"XPR-50",
				"",
				"Shields",
				"Assault Shield",
				"",
				"Pistols",
				"",
				"Five-Seven",
				"Tac-45",
				"B23R",
				"Executioner",
				"KAP-40",
				"Five-Seven Dual Wield",
				"Tac-45 Dual Wield",
				"B23R Dual Wield",
				"Executioner Dual Wield",
				"KAP-40 Dual Wield",
				"",
				"Launchers",
				"",
				"SMAW",
				"FHJ-18 AA",
				"RPG",
				"",
				"Specials",
				"",
				"Crossbow",
				"Ballistic Knife",
				"",
				"Misc",
				"",
				"Fake War Machine"
			});
			this.comboBox_0.Location = new Point(19, 19);
			this.comboBox_0.Name = "comboBox_0";
			this.comboBox_0.Size = new Size(248, 21);
			this.comboBox_0.TabIndex = 1;
			this.comboBox_0.Text = "Primary";
			this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
			this.tabPage_0.BackColor = SystemColors.Control;
			this.tabPage_0.Controls.Add(this.groupBox_0);
			this.tabPage_0.Location = new Point(4, 22);
			this.tabPage_0.Name = "tabPage_0";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(335, 376);
			this.tabPage_0.TabIndex = 1;
			this.tabPage_0.Text = "Class Mods";
			this.tabPage_0.Click += this.tabPage_0_Click;
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Location = new Point(-4, -25);
			this.tabControl_0.Name = "tabControl_0";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(343, 402);
			this.tabControl_0.TabIndex = 12;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(308, 261);
			base.Controls.Add(this.tabControl_0);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Name = "Form3";
			this.Text = "Form3";
			base.Load += this.Form3_Load;
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			this.tabPage_0.ResumeLayout(false);
			this.tabControl_0.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		
		private byte[] byte_0;

		
		private byte[] byte_1;

		
		private byte[] byte_10;

		
		private byte[] byte_11;

		
		private byte[] byte_12;

		
		private byte[] byte_13;

		
		private byte[] byte_14;

		
		private byte[] byte_2;

		
		private byte[] byte_3;

		
		private byte[] byte_4;

		
		private byte[] byte_5;

		
		private byte[] byte_6;

		
		private byte[] byte_7;

		
		private byte[] byte_8;

		
		private byte[] byte_9;

		
		private ComboBox comboBox_0;

		
		private ComboBox comboBox_1;

		
		private ComboBox comboBox_10;

		
		private ComboBox comboBox_2;

		
		private ComboBox comboBox_3;

		
		private ComboBox comboBox_4;

		
		private ComboBox comboBox_5;

		
		private ComboBox comboBox_6;

		
		private ComboBox comboBox_7;

		
		private ComboBox comboBox_8;

		
		private ComboBox comboBox_9;

		
		private IXboxConsole ginterface0_0;

		
		private GroupBox groupBox_0;

		
		private IContainer icontainer_0;

		
		private Label label_0;

		
		public string string_0;

		
		private TabControl tabControl_0;

		
		private TabPage tabPage_0;

		
		public uint uint_0;

		
		public uint uint_1;

		
		public uint uint_10;

		
		public uint uint_11;

		
		public uint uint_12;

		
		public uint uint_13;

		
		public uint uint_14;

		
		public uint uint_15;

		
		public uint uint_16;

		
		public uint uint_17;

		
		public uint uint_18;

		
		public uint uint_19;

		
		public uint uint_2;

		
		public uint uint_20;

		
		public uint uint_21;

		
		public uint uint_22;

		
		public uint uint_23;

		
		public uint uint_24;

		
		public uint uint_3;

		
		public uint uint_4;

		
		public uint uint_5;

		
		public uint uint_6;

		
		public uint uint_7;

		
		public uint uint_8;

		
		public uint uint_9;

		
		private WebClient webClient_0;

		
		private WebClient webClient_1;

		
		private XRPC xrpc_0;

		
		private IContainer components;
	}
}
