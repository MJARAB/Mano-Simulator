using System.Text;
namespace Simulator_MJARAB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Char Table(int a)
        {
            char aa = ' ';
            switch (a)
            {
                case 0:
                    aa = '0';
                    break;
                case 1:
                    aa = '1';
                    break;
                case 2:
                    aa = '2';
                    break;
                case 3:
                    aa = '3';
                    break;
                case 4:
                    aa = '4';
                    break;
                case 5:
                    aa = '5';
                    break;
                case 6:
                    aa = '6';
                    break;
                case 7:
                    aa = '7';
                    break;
                case 8:
                    aa = '8';
                    break;
                case 9:
                    aa = '9';
                    break;
                case 10:
                    aa = 'A';
                    break;
                case 11:
                    aa = 'B';
                    break;
                case 12:
                    aa = 'C';
                    break;
                case 13:
                    aa = 'D';
                    break;
                case 14:
                    aa = 'E';
                    break;
                case 15:
                    aa = 'F';
                    break;
            }
            return aa;
        }
        public string CorrectNumber(string number)
        {
            StringBuilder cnumber = new StringBuilder("");
            int j = 0;
            for (int i = 4; i > number.Count(); i--)
            {
                cnumber.Append("0");
            }
            cnumber.Append(number);
            return Convert.ToString(cnumber);
        }
        public string Hex_to_bin(string hexvalue)
        {
            string binaryval = "";
            binaryval = Convert.ToString(Convert.ToInt32(hexvalue, 16), 2);

            for (int i = binaryval.Length; i < 16; i++)
            {
                binaryval = "0" + binaryval;
            }

            return binaryval;
        }
        public string Bin_to_hex(string str)
        {
            string hexval = "";
            hexval = Convert.ToUInt16(str, 2).ToString("X4");
            return hexval;
        }
        public string Dec_to_hex(string str)
        {
            if (str[0] != '-')
            {
                int decval = Convert.ToInt32(str);
                string hexval = (decval).ToString("X");
                return hexval;
            }
            else
            {
                short decval = Convert.ToInt16(str);
                Int16 d = decval;
                string s = Convert.ToString(d, 2);
                s = Bin_to_hex(s);
                return s;
            }

        }
        public int decimalValue(char x)
        {
            if (x == 'A' || x == 'a')
            {
                return 10;
            }
            if (x == 'B' || x == 'b')
            {
                return 11;
            }
            if (x == 'C' || x == 'c')
            {
                return 12;
            }
            if (x == 'D' || x == 'd')
            {
                return 13;
            }
            if (x == 'E' || x == 'e')
            {
                return 14;
            }
            if (x == 'F' || x == 'f')
            {
                return 15;
            }
            return x - '0';
        }
        public string addHexadecimal(String a, String b)
        {
            int n = a.Length;
            int m = b.Length;
            int i = n - 1;
            int j = m - 1;
            int temp = 0;
            int carry = 0;
            String result = "";
            char[] hexaValue = {
            '0' , '1' , '2' , '3' , '4' , '5' , '6' , '7' , '8' ,
           '9' , 'A' , 'B' , 'C' , 'D' , 'E'
        };
            while (i >= 0 || j >= 0)
            {
                if (i >= 0 && j >= 0)
                {
                    temp = this.decimalValue(a[i]) +
                      this.decimalValue(b[j]) + carry;
                    i--;
                    j--;
                }
                else if (i >= 0)
                {
                    temp = this.decimalValue(a[i]) + carry;
                    i--;
                }
                else
                {
                    temp = this.decimalValue(b[j]) + carry;
                    j--;
                }
                result = hexaValue[(temp % 16)] + result;
                carry = temp / 16;
            }
            if (carry != 0)
            {
                result = hexaValue[carry] + result;
            }
            return result;
        }
        public string Hex_to_dec(string str)
        {
            int num;
            num = int.Parse(str, System.Globalization.NumberStyles.HexNumber);
            string decval = num.ToString();
            return decval;
        }
        public string Hex_flip(string hex)
        {
            string fliphex = "";
            for(int i = 0; i < hex.Length; i++)
            {
                fliphex += Dec_to_hex(Convert.ToString(15 - Convert.ToInt32(Hex_to_dec(Convert.ToString(hex[i])))));
            }
            return fliphex;
        }
        public String NewAddress(String Address)
        {
            string NextAddress = "";
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[1].Text.ToString() == Address)
                {
                    NextAddress = listView1.Items[i + 1].SubItems[1].Text.ToString();
                }
            }
            return NextAddress;
        }
        public String NumberAddress(int number)
        {
            string MyAddress = "";
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (i == number)
                {
                    MyAddress = listView1.Items[i].SubItems[1].Text.ToString();
                }
            }
            return MyAddress;
        }
        public string Ram(String Address)
        {
            string hex = "";
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[1].Text.ToString() == Address)
                {
                    hex = listView1.Items[i].SubItems[3].Text.ToString();
                }
            }
            return hex;
        }
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage newfilecontrol = new TabPage();
            newfilecontrol.Text = "Untitled";
            newfilecontrol.BackColor = Color.FromArgb(42, 42, 42);
            newfilecontrol.ForeColor = Color.White;
            RichTextBox newlabel = new RichTextBox();
            newlabel.BackColor = Color.FromArgb(40, 40, 40);
            newlabel.ForeColor = Color.FromArgb(128, 255, 255);
            newlabel.Dock = DockStyle.Left;
            newlabel.Width = tabControl2.Width / 7 - 8;
            newlabel.RightToLeft = RightToLeft.Yes;
            newlabel.Font = new Font(newlabel.Font, FontStyle.Bold);
            RichTextBox newText = new RichTextBox();
            newText.Multiline = true;
            newText.BackColor = Color.FromArgb(42, 42, 42);
            newText.ForeColor = Color.White;
            newText.Dock = DockStyle.Right;
            newText.Font = new Font(newText.Font, FontStyle.Bold);
            newText.TextChanged += Code_Changed;
            newText.Width = (tabControl2.Width / 7) * 6 - 4;
            newfilecontrol.Controls.Add(newlabel);
            newfilecontrol.Controls.Add(newText);
            tabControl2.Controls.Add(newfilecontrol);
            tabControl2.SelectedTab = newfilecontrol;
            newlabel.Text = "";
            linesCount = newText.Lines.Length;
        }

        Color Memory_Color = Color.Green;
        Color Register_Color = Color.Blue;
        Color IO_Color = Color.Yellow;
        Color Directives_Color = Color.Orange;

        string[] Memory = new string[7] { "AND", "ADD", "LDA", "STA", "BUN", "BSA", "ISZ" };
        string[] Register = new string[11] { "CLA", "CLE", "CMA", "CME", "CIR", "CIL", "INC", "SPA", "SNA", "SZA", "SZE" };
        string[] IO = new string[6] { "INP", "OUT", "SKI", "SKO", "ION", "IOF" };
        string[] Directives = new string[5] { "ORG", "START", "END", "DEC", "HEX" };
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            openFile1.DefaultExt = "*.asm";
            openFile1.Filter = "Assembly Files|*.asm";
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile1.FileName.Length > 0)
            {
                TabPage newfilecontrol = new TabPage();
                newfilecontrol.Text = openFile1.FileName.Split('\\')[openFile1.FileName.Split('\\').Length - 1];
                newfilecontrol.BackColor = Color.FromArgb(42, 42, 42);
                newfilecontrol.ForeColor = Color.White;
                RichTextBox newlabel = new RichTextBox();
                newlabel.BackColor = Color.FromArgb(40, 40, 40);
                newlabel.ForeColor = Color.FromArgb(128, 255, 255);
                newlabel.Dock = DockStyle.Left;
                newlabel.Width = tabControl2.Width / 7 - 8;
                newlabel.RightToLeft = RightToLeft.Yes;
                newlabel.Font = new Font(newlabel.Font, FontStyle.Bold);
                RichTextBox newText = new RichTextBox();
                newText.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
                newText.BackColor = Color.FromArgb(42, 42, 42);
                newText.ForeColor = Color.White;
                newText.Dock = DockStyle.Right;
                newText.Width = (tabControl2.Width / 7) * 6 - 4;
                newText.Font = new Font(newText.Font, FontStyle.Bold);
                newfilecontrol.Controls.Add(newlabel);
                newfilecontrol.Controls.Add(newText);
                tabControl2.Controls.Add(newfilecontrol);
                tabControl2.SelectedTab = newfilecontrol;
                newText.TextChanged += Code_Changed;
                this.CheckKeyword(newText, ",", Color.Red, 0);
                this.CheckKeyword(newText, "HLT", Color.Pink, 0);
                foreach (string a1 in Memory)
                {
                    this.CheckKeyword(newText, a1, Memory_Color, 0);
                }
                foreach (string a2 in Register)
                {
                    this.CheckKeyword(newText, a2, Register_Color, 0);
                }
                foreach (string a3 in IO)
                {
                    this.CheckKeyword(newText, a3, IO_Color, 0);
                }
                foreach (string a4 in Directives)
                {
                    this.CheckKeyword(newText, a4, Directives_Color, 0);
                }
                newlabel.Text = "";
                linesCount = newText.Lines.Length;
                for (int i = 0; i < newText.Lines.Length; i++)
                {
                    newlabel.Text += " " + (i + 1).ToString() + "\n";
                }
            }
        }
        private void Code_Changed(object sender, EventArgs e)
        {
            RichTextBox textcode = (RichTextBox)sender;
            foreach (RichTextBox textnumber in tabControl2.SelectedTab.Controls)
            {
                if (textnumber.BackColor == Color.FromArgb(40, 40, 40))
                {
                    if (textcode.Lines.Length < linesCount)
                    {
                        textnumber.Text = "";
                        for (int i = 1; i <= textcode.Lines.Length; i++)
                        {
                            textnumber.Text += " " + i.ToString() + "\n";
                        }
                    }
                    else if (textcode.Lines.Length > linesCount)
                    {
                        if (linesCount == 0)
                            textnumber.Text = "";
                        for (int i = linesCount + 1; i <= textcode.Lines.Length; i++)
                        {
                            textnumber.Text += " " + i.ToString() + "\n";
                        }
                    }
                    linesCount = textcode.Lines.Length;
                    if (linesCount == 0)
                    {
                        textnumber.Text += " 1\n";
                    }
                }
            }
            this.CheckKeyword(textcode, ",", Color.Red, 0);
            this.CheckKeyword(textcode,"HLT", Color.Pink, 0);
            foreach (string a1 in Memory)
            {
                this.CheckKeyword(textcode, a1, Memory_Color, 0);
            }
            foreach (string a2 in Register)
            {
                this.CheckKeyword(textcode, a2, Register_Color, 0);
            }
            foreach (string a3 in IO)
            {
                this.CheckKeyword(textcode, a3, IO_Color, 0);
            }
            foreach (string a4 in Directives)
            {
                this.CheckKeyword(textcode, a4, Directives_Color, 0);
            }
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage newtabpage in tabControl2.Controls)
            {
                if (tabControl2.SelectedTab == newtabpage)
                {
                    tabControl2.Controls.Remove(newtabpage);
                }
            }
        }

        private void saveCTRLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.asm";
            saveFile1.Filter = "Assembly Files (*.asm)|*.asm";
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                foreach (TabPage newtabpage in tabControl2.Controls)
                {
                    if (tabControl2.SelectedTab == newtabpage)
                    {
                        foreach (RichTextBox textcode in newtabpage.Controls)
                        {
                            textcode.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                        }
                    }
                }
            }
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.asm";
            saveFile1.Filter = "Assembly Files (*.asm)|*.asm";
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                foreach (TabPage newtabpage in tabControl2.Controls)
                {
                    foreach (RichTextBox textcode in newtabpage.Controls)
                    {
                        textcode.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.asm";
            saveFile1.Filter = "Assembly Files (*.asm)|*.asm";
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                foreach (TabPage newtabpage in tabControl2.Controls)
                {
                    if (tabControl2.SelectedTab == newtabpage)
                    {
                        foreach (RichTextBox textcode in newtabpage.Controls)
                        {
                            textcode.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                        }
                    }
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string message = "Mohammad Javad Arab 9926783" + "\n" + "Studens at Isfahan University of Thechnology" + "\n" + "Department of Electrical and Computer Engineering";
            string title = "About";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (TabPage newtabpage in tabControl2.Controls)
            {
                if (tabControl2.SelectedTab == newtabpage)
                {
                    foreach (RichTextBox textcode in newtabpage.Controls)
                    {
                        textcode.Clear();
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Label", 70);
            listView1.Columns.Add("Address", 70);
            listView1.Columns.Add("Instruction", 100);
            listView1.Columns.Add("Hex", 60);

            string[] arr = new string[4];
            ListViewItem itm;

            for (int i = 0; i < 4096; i++)
            {
                int a = i % 16;
                int b = (i / 16) % 16;
                int c = i / 256;
                arr[1] = Convert.ToString(Table(c)) + Convert.ToString(Table(b)) + Convert.ToString(Table(a));
                arr[3] = "0000";
                itm = new ListViewItem(arr);
                if (i % 2 == 0)
                {
                    itm.BackColor = Color.White;
                }
                else if (i % 2 == 1)
                {
                    itm.BackColor = Color.Gainsboro;
                }
                listView1.Items.Add(itm);
            }

        }


        private int linesCount = 0;

        private void CheckKeyword(RichTextBox rchtxt,string word, Color color, int startIndex)
        {
            if (rchtxt.Text.Contains(word))
            {
                int index = -1;
                int selectStart = rchtxt.SelectionStart;

                while ((index = rchtxt.Text.IndexOf(word, (index + 1))) != -1)
                {
                    rchtxt.Select((index + startIndex), word.Length);
                    rchtxt.SelectionColor = color;
                    rchtxt.Select(selectStart, 0);
                    rchtxt.SelectionColor = Color.White;
                }
            }
        }
        string FirstAddress = "000";
        string FirstAddress2 = "000";
        private void assembleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssembleCode();
        }

        private void tabControl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            foreach (TabPage newtabpage in tabControl2.Controls)
            {
                if (tabControl2.SelectedTab == newtabpage)
                {
                    foreach (RichTextBox textcode in newtabpage.Controls)
                    {
                        if (textcode.BackColor == Color.FromArgb(42, 42, 42))
                        {
                            e.KeyChar = char.ToUpper(e.KeyChar);
                        }
                    }
                }
            }
        }
        int clk = 4;
        int linestep = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 40; i++)
            {
                CompileCode();
                Task.Delay(4000/Convert.ToInt32(comboBox1.Text)).Wait();
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Memory_Color = Change_Color(comboBox2.Text);
            Register_Color = Change_Color(comboBox3.Text);
            IO_Color = Change_Color(comboBox4.Text);
            Directives_Color = Change_Color(comboBox5.Text);
            foreach (TabPage newtabpage in tabControl2.Controls)
            {
                foreach (RichTextBox texts in newtabpage.Controls)
                {
                    if (texts.BackColor == Color.FromArgb(42, 42, 42))
                    {
                        string[] Memory = new string[7] { "AND", "ADD", "LDA", "STA", "BUN", "BSA", "ISZ" };
                        string[] Register = new string[11] { "CLA", "CLE", "CMA", "CME", "CIR", "CIL", "INC", "SPA", "SNA", "SZA", "SZE" };
                        string[] IO = new string[6] { "INP", "OUT", "SKI", "SKO", "ION", "IOF" };
                        string[] Directives = new string[5] { "ORG", "START", "END", "DEC", "HEX" };
                        this.CheckKeyword(texts, ",", Color.Red, 0);
                        this.CheckKeyword(texts, "HLT", Color.Pink, 0);
                        foreach (string a1 in Memory)
                        {
                            this.CheckKeyword(texts, a1, Memory_Color, 0);
                        }
                        foreach (string a2 in Register)
                        {
                            this.CheckKeyword(texts, a2, Register_Color, 0);
                        }
                        foreach (string a3 in IO)
                        {
                            this.CheckKeyword(texts, a3, IO_Color, 0);
                        }
                        foreach (string a4 in Directives)
                        {
                            this.CheckKeyword(texts, a4, Directives_Color, 0);
                        }
                    }
                }
            }
        }
        public Color Change_Color(string colorcode)
        {
            Color range = Color.White;
            switch (colorcode)
            {
                case "Blue":
                    range = Color.Blue;
                    break;
                case "Green":
                    range = Color.Green;
                    break;
                case "Red":
                    range = Color.Red;
                    break;
                case "Yellow":
                    range = Color.Yellow;
                    break;
                case "Orange":
                    range = Color.Orange;
                    break;
                case "Purple":
                    range = Color.Purple;
                    break;
                case "White":
                    range = Color.White;
                    break;
                case "Black":
                    range = Color.Black;
                    break;
            }
            return range;
        }
        public void AssembleCode()
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                int a = i % 16;
                int b = (i / 16) % 16;
                int c = i / 256;
                if (i % 2 == 0)
                {
                    listView1.Items[i].BackColor = Color.White;
                }
                else if (i % 2 == 1)
                {
                    listView1.Items[i].BackColor = Color.Gainsboro;
                }
                listView1.Items[i].SubItems[0].Text = "";
                listView1.Items[i].SubItems[1].Text = Convert.ToString(Table(c)) + Convert.ToString(Table(b)) + Convert.ToString(Table(a));
                listView1.Items[i].SubItems[2].Text = "";
                listView1.Items[i].SubItems[3].Text = "0000";
            }
            int neshan = 0;
            int tashkhis = 0;
            int CheckCompile2 = 0;
            Dictionary<string, string> MemoryDic = new Dictionary<string, string>();
            MemoryDic["AND"] = "0 8";
            MemoryDic["ADD"] = "1 9";
            MemoryDic["LDA"] = "2 A";
            MemoryDic["STA"] = "3 B";
            MemoryDic["BUN"] = "4 C";
            MemoryDic["BSA"] = "5 D";
            MemoryDic["ISZ"] = "6 E";
            Dictionary<string, string> RegisterDic = new Dictionary<string, string>();
            RegisterDic["CLA"] = "7800";
            RegisterDic["CLE"] = "7400";
            RegisterDic["CMA"] = "7200";
            RegisterDic["CME"] = "7100";
            RegisterDic["CIR"] = "7080";
            RegisterDic["CIL"] = "7040";
            RegisterDic["INC"] = "7020";
            RegisterDic["SPA"] = "7010";
            RegisterDic["SNA"] = "7008";
            RegisterDic["SZA"] = "7004";
            RegisterDic["SZE"] = "7002";
            Dictionary<string, string> IOdic = new Dictionary<string, string>();
            IOdic["INP"] = "F800";
            IOdic["INP"] = "F400";
            IOdic["INP"] = "F200";
            IOdic["INP"] = "F100";
            IOdic["INP"] = "F080";
            IOdic["INP"] = "F040";
            List<string> OtherWords = new List<string>();
            foreach (TabPage newtabpage in tabControl2.Controls)
            {
                if (tabControl2.SelectedTab == newtabpage)
                {
                    foreach (RichTextBox textcode in newtabpage.Controls)
                    {
                        if (textcode.Text.Contains("ORG") == false)
                        {
                            FirstAddress = "000";
                            FirstAddress2 = "000";
                            Avalin = FirstAddress;
                            tabControl1.SelectedTab = tabPage3;
                            listView1.Items[0].BackColor = Color.Gray;
                            listView1.EnsureVisible(int.Parse(Hex_to_dec(FirstAddress)));
                        }
                        for (int i = 0; i < textcode.Lines.Length; i++)
                        {
                            if (MemoryDic.ContainsKey(textcode.Lines[i].Split(' ')[0].Trim().ToUpper()))
                            {
                                int CheckMemory2 = 0;
                                for (int j = 0; j < listView1.Items.Count; j++)
                                {
                                    if (listView1.Items[j].SubItems[1].Text.ToString() == FirstAddress)
                                    {
                                        for (int k = 0; k < textcode.Lines.Length; k++)
                                        {
                                            if (textcode.Lines[k].Split(',')[0].Trim().ToUpper() == textcode.Lines[i].Split(' ')[1].Trim().ToUpper())
                                            {
                                                for (int m = 0; m < listView1.Items.Count; m++)
                                                {
                                                    if (listView1.Items[m].SubItems[0].Text == textcode.Lines[i].Split(' ')[1].Trim().ToUpper())
                                                    {
                                                        CheckMemory2 = 1;
                                                    }
                                                }
                                                if (CheckMemory2 == 0)
                                                {
                                                    OtherWords.Add(textcode.Lines[i].Split(' ')[1].Trim().ToUpper());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        for (int i = 0; i < textcode.Lines.Length; i++)
                        {
                            if (textcode.Lines[i].Split(' ')[0].Trim().ToUpper() == "ORG")
                            {
                                for (int j = 0; j < listView1.Items.Count; j++)
                                {
                                    if (listView1.Items[j].SubItems[1].Text.ToString() == textcode.Lines[i].Split(' ')[1].Trim())
                                    {
                                        FirstAddress = textcode.Lines[i].Split(' ')[1].Trim();
                                        FirstAddress2 = FirstAddress;
                                        if (neshan == 0)
                                        {
                                            Avalin = FirstAddress;
                                            listView1.EnsureVisible(int.Parse(Hex_to_dec(FirstAddress)) + 8);
                                            neshan = 1;
                                        }
                                        listView1.Items[j].BackColor = Color.Gray;
                                        tashkhis = 1;
                                    }
                                }
                                if (tashkhis == 0)
                                {
                                    label45.Text = "Invalid Address";
                                    tabControl1.SelectedTab = tabPage2;
                                }
                            }
                            else if (MemoryDic.ContainsKey(textcode.Lines[i].Split(' ')[0].Trim().ToUpper()))
                            {
                                int CheckMemory = 0;
                                for (int j = 0; j < listView1.Items.Count; j++)
                                {
                                    if (listView1.Items[j].SubItems[1].Text.ToString() == FirstAddress)
                                    {
                                        int CheckCompile = 0;
                                        for (int k = 0; k < textcode.Lines.Length; k++)
                                        {
                                            if (textcode.Lines[k].Split(',')[0].Trim().ToUpper() == textcode.Lines[i].Split(' ')[1].Trim().ToUpper())
                                            {
                                                CheckCompile = 1;
                                                for (int m = 0; m < listView1.Items.Count; m++)
                                                {
                                                    if (listView1.Items[m].SubItems[0].Text == textcode.Lines[i].Split(' ')[1].Trim().ToUpper())
                                                    {
                                                        CheckMemory = 1;
                                                    }
                                                }
                                                if (CheckMemory == 0)
                                                {
                                                    listView1.Items[j + k - i].SubItems[0].Text = textcode.Lines[k].Split(',')[0].Trim().ToUpper();
                                                    listView1.Items[j + k - i].SubItems[2].Text = textcode.Lines[k].Split(',')[1].Trim().ToUpper();
                                                    if (textcode.Lines[k].Contains("DEC") == true)
                                                    {
                                                        listView1.Items[j + k - i].SubItems[3].Text = CorrectNumber(Dec_to_hex(textcode.Lines[k].Split("DEC")[1].Trim()));
                                                    }
                                                    else if (textcode.Lines[k].Contains("HEX") == true)
                                                    {
                                                        listView1.Items[j + k - i].SubItems[3].Text = CorrectNumber(textcode.Lines[k].Split("HEX")[1].Trim());
                                                    }
                                                    else if (MemoryDic.ContainsKey(textcode.Lines[k].Split(',')[1].Trim().ToUpper().Split(' ')[0].Trim().ToUpper()))
                                                    {
                                                        for (int n = 0; n < textcode.Lines.Length; n++)
                                                        {
                                                            if (textcode.Lines[n].Split(',')[0].Trim().ToUpper() == textcode.Lines[k].Split(',')[1].Trim().ToUpper().Split(' ')[1].Trim().ToUpper())
                                                            {
                                                                if (textcode.Lines[k].Contains(" I") == true)
                                                                {
                                                                    listView1.Items[j + k - i].SubItems[3].Text = MemoryDic[textcode.Lines[k].Split(',')[1].Trim().ToUpper().Split(' ')[0].Trim().ToUpper()].Split(" ")[1] + NumberAddress(Convert.ToInt32(Convert.ToString(j + n - i)));
                                                                }
                                                                else if (textcode.Lines[k].Contains(" I") == false)
                                                                {
                                                                    listView1.Items[j + k - i].SubItems[3].Text = MemoryDic[textcode.Lines[k].Split(',')[1].Trim().ToUpper().Split(' ')[0].Trim().ToUpper()].Split(" ")[0] + NumberAddress(Convert.ToInt32(Convert.ToString(j + n - i)));
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else if (RegisterDic.ContainsKey(textcode.Lines[k].Split(',')[1].Trim().ToUpper()))
                                                    {
                                                        listView1.Items[j + k - i].SubItems[3].Text = RegisterDic[textcode.Lines[k].Split(',')[1].Trim().ToUpper()];
                                                    }
                                                    else if (IOdic.ContainsKey(textcode.Lines[k].Split(',')[1].Trim().ToUpper()))
                                                    {
                                                        listView1.Items[j + k - i].SubItems[3].Text = IOdic[textcode.Lines[k].Split(',')[1].Trim().ToUpper()];
                                                    }
                                                }
                                                if (textcode.Lines[i].Contains(" I") == true)
                                                {
                                                    listView1.Items[j].SubItems[3].Text = MemoryDic[textcode.Lines[i].Split(' ')[0].Trim().ToUpper()].Split(" ")[1] + NumberAddress(Convert.ToInt32(Convert.ToString(j + k - i)));
                                                }
                                                else if (textcode.Lines[i].Contains(" I") == false)
                                                {
                                                    listView1.Items[j].SubItems[3].Text = MemoryDic[textcode.Lines[i].Split(' ')[0].Trim().ToUpper()].Split(" ")[0] + NumberAddress(Convert.ToInt32(Convert.ToString(j + k - i)));
                                                }
                                            }
                                        }
                                        listView1.Items[j].SubItems[2].Text = textcode.Lines[i];
                                        if (CheckCompile == 0)
                                        {
                                            CheckCompile2 = 1;
                                        }
                                    }
                                }
                                FirstAddress = NewAddress(FirstAddress);
                            }
                            else if (RegisterDic.ContainsKey(textcode.Lines[i].Split(' ')[0].Trim().ToUpper()))
                            {
                                for (int j = 0; j < listView1.Items.Count; j++)
                                {
                                    if (listView1.Items[j].SubItems[1].Text.ToString() == FirstAddress)
                                    {
                                        listView1.Items[j].SubItems[2].Text = textcode.Lines[i].Split(' ')[0].Trim().ToUpper();
                                        listView1.Items[j].SubItems[3].Text = RegisterDic[textcode.Lines[i].Split(' ')[0].Trim().ToUpper()];
                                    }
                                }
                                FirstAddress = NewAddress(FirstAddress);
                            }
                            else if (IOdic.ContainsKey(textcode.Lines[i].Split(' ')[0].Trim().ToUpper()))
                            {
                                for (int j = 0; j < listView1.Items.Count; j++)
                                {
                                    if (listView1.Items[j].SubItems[1].Text.ToString() == FirstAddress)
                                    {
                                        listView1.Items[j].SubItems[2].Text = textcode.Lines[i].Split(' ')[0].Trim().ToUpper();
                                        listView1.Items[j].SubItems[3].Text = IOdic[textcode.Lines[i].Split(' ')[0].Trim().ToUpper()];
                                    }
                                }
                                FirstAddress = NewAddress(FirstAddress);
                            }
                            else if (OtherWords.Contains(textcode.Lines[i].Split(',')[0].Trim().ToUpper()) == true)
                            {
                                FirstAddress = NewAddress(FirstAddress);
                            }
                            else if (textcode.Lines[i].Split(' ')[0].Trim().ToUpper() == "HEX")
                            {
                                for (int j = 0; j < listView1.Items.Count; j++)
                                {
                                    if (listView1.Items[j].SubItems[1].Text.ToString() == FirstAddress)
                                    {
                                        listView1.Items[j].SubItems[2].Text = textcode.Lines[i];
                                        listView1.Items[j].SubItems[3].Text = textcode.Lines[i].Split(' ')[1].Trim().ToUpper();
                                    }
                                }
                                FirstAddress = NewAddress(FirstAddress);
                            }
                            else if (textcode.Lines[i].Split(' ')[0].Trim().ToUpper() == "DEC")
                            {
                                for (int j = 0; j < listView1.Items.Count; j++)
                                {
                                    if (listView1.Items[j].SubItems[1].Text.ToString() == FirstAddress)
                                    {
                                        listView1.Items[j].SubItems[2].Text = textcode.Lines[i];
                                        listView1.Items[j].SubItems[3].Text = CorrectNumber(Dec_to_hex(textcode.Lines[i].Split(' ')[1].Trim().ToUpper()));
                                    }
                                }
                                FirstAddress = NewAddress(FirstAddress);
                            }
                            else if (textcode.Lines[i].Split(' ')[0].Trim().ToUpper() == "HLT")
                            {
                                for (int j = 0; j < listView1.Items.Count; j++)
                                {
                                    if (listView1.Items[j].SubItems[1].Text.ToString() == FirstAddress)
                                    {
                                        listView1.Items[j].SubItems[2].Text = textcode.Lines[i].Split(' ')[0].Trim().ToUpper();
                                        listView1.Items[j].SubItems[3].Text = "7001";
                                    }
                                }
                                FirstAddress = NewAddress(FirstAddress);
                            }
                        }
                    }
                }
            }
            if (CheckCompile2 == 1)
            {
                label45.Text = "Unrecognized Label name";
                tabControl1.SelectedTab = tabPage2;
            }
            else if (tashkhis != 0 && CheckCompile2 == 0)
            {
                MessageBox.Show("Complition Successful.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tabControl1.SelectedTab = tabPage3;
            }
            if (MemoryAddress == "000")
            {
                MemoryAddress = FirstAddress2;
                lbl_S.Text = "1";
                lbl_PC.Text = MemoryAddress;
            }
            clk = 4;
            clock = 0;
            MemoryAddress = Avalin;
            lbl_PC.Text = Avalin;
            lbl_SC.Text = "0";
            lbl_AR.Text = "000";
            lbl_IR.Text = "0000";
            lbl_DR.Text = "0000";
            lbl_AC.Text = "0000";
            lbl_TR.Text = "0000";
            lbl_INPR.Text = "000";
            lbl_OUTR.Text = "";
            lbl_I.Text = "0";
            lbl_S.Text = "0";
            lbl_E.Text = "0";
            lbl_R.Text = "0";
            lbl_IEN.Text = "0";
            lbl_FGI.Text = "0";
            lbl_FGO.Text = "0";
            lbl_Micro.Text = "";
        }
        int clock = 0;
        string MemoryAddress = "000";
        public void CompileCode()
        {
            if (clk == 0)
            {
                clk++;
                lbl_Micro.Text = "PC <- PC + 1";
                lbl_PC.Text = NewAddress(lbl_PC.Text);
            }
            else if (clk == 1)
            {
                clk++;
                clock++;
                lbl_SC.Text = clock.ToString();
                StringBuilder s_AR = new StringBuilder(lbl_AR.Text);
                StringBuilder s_IR = new StringBuilder(lbl_IR.Text);
                for (int j = 0; j < 3; j++)
                {
                    s_AR[j] = s_IR[j + 1];
                }
                lbl_AR.Text = Convert.ToString(s_AR);
                lbl_Micro.Text = "AR <- IR(0-11)";
            }
            else if (clk == 2)
            {
                clk++;
                StringBuilder s_IR = new StringBuilder(lbl_IR.Text);
                lbl_I.Text = Hex_to_bin(s_IR.ToString())[0].ToString();
                lbl_Micro.Text = "I <- IR(15)";
            }
            else if (clk == 3)
            {
                clk++;
                lbl_Micro.Text = "D0,.....,D7 <- Decode IR(12-14)";
            }
            else
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text == MemoryAddress)
                    {
                        if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("CLA"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_AC.Text = "0";
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "AC <- 0  , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("CLE"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_E.Text = "0";
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "E <- 0  , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("CMA"))
                        {
                            if (clk == 4)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_DR.Text = Ram(lbl_AR.Text);
                                lbl_Micro.Text = "DR <- M[AR]";
                            }
                            else if (clk == 5)
                            {
                                clk++;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "SC <- 0";
                            }
                            else if (clk == 6)
                            {
                                clk++;
                                lbl_AC.Text = lbl_DR.Text;
                                lbl_Micro.Text = "AC <- DR";
                            }
                            else if (clk == 7)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_AR.Text = lbl_PC.Text;
                                lbl_Micro.Text = "AR <- PC";
                            }
                            else if (clk == 8)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_IR.Text = Ram(lbl_AR.Text);
                                lbl_Micro.Text = "IR <- M[AR]";
                                clk = 0;
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("CME"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "E <- ~E  , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("CIR"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "AC <- shr  , AC(15)<-E , E <- AC(0)";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("CIL"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "AC <- shl  , AC(0)<-E , E <- AC(15)";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("INC"))
                        {
                            if (clk == 4)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_AC.Text = Hex_flip(lbl_AC.Text);
                                lbl_Micro.Text = "AC <- (AC)'";
                            }
                            else if (clk == 5)
                            {
                                clk++;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "SC <- 0";
                            }
                            else if (clk == 6)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_AR.Text = lbl_PC.Text;
                                lbl_Micro.Text = "AR <- PC";
                            }
                            else if (clk == 7)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_IR.Text = Ram(lbl_AR.Text);
                                lbl_Micro.Text = "IR <- M[AR]";
                                clk = 0;
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("SPA"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "PC <- PC+1  , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("SNA"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "PC <- PC+1  , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("SZA"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "PC <- PC+1  , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("SZE"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "PC <- PC+1  , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("AND"))
                        {
                            if (clk == 4)
                            {
                                clk++;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "AR <- M[AR]";
                            }
                            else if (clk == 5)
                            {
                                clk++;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "DR <- M[AR]";
                            }
                            else if (clk == 6)
                            {
                                clk=0;
                                clock=0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "AC <- AC^DR  , SC <- 0";
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("ADD"))
                        {
                            if (clk == 4)
                            {
                                clk++;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "SC <- 0";
                            }
                            else if (clk == 5)
                            {
                                clk++;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_AC.Text = CorrectNumber(Dec_to_hex(Convert.ToString(Convert.ToInt32(Hex_to_dec(lbl_AC.Text)) + 1)));
                                lbl_Micro.Text = "AC <- AC + 1";
                            }
                            else if (clk == 6)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_AR.Text = lbl_PC.Text;
                                lbl_Micro.Text = "AR <- PC";
                            }
                            else if (clk == 7)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_IR.Text = Ram(lbl_AR.Text);
                                lbl_Micro.Text = "IR <- M[AR]";
                                clk = 0;
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("LDA"))
                        {
                            if (clk == 4)
                            {
                                clk++;
                                clock++;
                                lbl_AR.Text = lbl_PC.Text;
                                lbl_Micro.Text = "AR <- PC";
                                lbl_SC.Text = clock.ToString();
                            }
                            else if (clk == 5)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_IR.Text = Ram(lbl_AR.Text);
                                lbl_Micro.Text = "IR <- M[AR]";
                                clk = 0;
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("STA"))
                        {
                            if (clk == 4)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_DR.Text = Ram(lbl_AR.Text);
                                lbl_Micro.Text = "DR <- M[AR]";
                            }
                            else if (clk == 5)
                            {
                                clk++;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "SC <- 0";
                            }
                            else if (clk == 6)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_AC.Text = CorrectNumber(addHexadecimal(lbl_AC.Text, lbl_DR.Text));
                                lbl_Micro.Text = "AC <- AC + DR";
                            }
                            else if (clk == 7)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_AR.Text = lbl_PC.Text;
                                lbl_Micro.Text = "AR <- PC";
                            }
                            else if (clk == 8)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_IR.Text = Ram(lbl_AR.Text);
                                lbl_Micro.Text = "IR <- M[AR]";
                                clk = 0;
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("BUN"))
                        {
                            if (clk == 4)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "AR <- M[AR]";
                            }
                            else if (clk == 5)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "PC <- AR , SC <- 0";
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("BSA"))
                        {
                            if (clk == 4)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "AR <- M[AR]";
                            }
                            else if (clk == 5)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "M[AR] <- PC , AR <- AR+1";
                            }
                            else if (clk == 6)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "PC <- AR , SC <- 0";
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("ISZ"))
                        {
                            if (clk == 4)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "AR <- M[AR]";
                            }
                            else if (clk == 5)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "DR <- M[AR]";
                            }
                            else if (clk == 6)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "DR <- DR+1";
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("INP"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "AC(0-7) <- INPR , FGI <- 0 , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("OUT"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "OUTR <- AC(0-7), FGO <- 0 , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("SKI"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "PC <- PC+1 , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("SKO"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_Micro.Text = "PC <- PC+1 , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("ION"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_IEN.Text = "1";
                                lbl_Micro.Text = "IEN <- 1 , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("IOF"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                                lbl_IEN.Text = "0";
                                lbl_Micro.Text = "IEN <- 0 , SC <- 0";
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("DEC"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("HEX"))
                        {
                            if (clk == 4)
                            {
                                clk = 0;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                MemoryAddress = NewAddress(MemoryAddress);
                                if (listView1.Items[i].BackColor == Color.Gray)
                                {
                                    if (i % 2 == 0)
                                    {
                                        listView1.Items[i].BackColor = Color.White;
                                    }
                                    else if (i % 2 == 1)
                                    {
                                        listView1.Items[i].BackColor = Color.Gainsboro;
                                    }
                                    listView1.Items[i + 1].BackColor = Color.Gray;
                                }
                            }
                        }
                        else if (listView1.Items[i].SubItems[2].Text.Split(" ")[0] == ("HLT"))
                        {
                            if (clk == 4)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "M[AR] <- AC";
                            }
                            else if (clk == 5)
                            {
                                clk++;
                                clock = 0;
                                lbl_SC.Text = clock.ToString();
                                lbl_Micro.Text = "SC <- 0";
                            }
                            else if (clk == 6)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_AR.Text = lbl_PC.Text;
                                lbl_Micro.Text = "AR <- PC";
                            }
                            else if (clk == 7)
                            {
                                clk++;
                                clock++;
                                lbl_SC.Text = clock.ToString();
                                lbl_IR.Text = Ram(lbl_AR.Text);
                                lbl_Micro.Text = "IR <- M[AR]";
                                clk = 0;
                                MemoryAddress = NewAddress(MemoryAddress);
                            }
                        }
                    }
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CompileCode();
        }
        string Avalin = "000";
        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listView1.Items[i].BackColor = Color.White;
                }
                else if (i % 2 == 1)
                {
                    listView1.Items[i].BackColor = Color.Gainsboro;
                }
                if ( listView1.Items[i].SubItems[1].Text.ToString() == Avalin)
                {
                    listView1.Items[i].BackColor = Color.Gray;
                }
            }
            clk = 4;
            clock = 0;
            MemoryAddress = Avalin;
            lbl_PC.Text = Avalin;
            lbl_SC.Text = "0";
            lbl_AR.Text = "000";
            lbl_IR.Text = "0000";
            lbl_DR.Text = "0000";
            lbl_AC.Text = "0000";
            lbl_TR.Text = "0000";
            lbl_INPR.Text = "000";
            lbl_OUTR.Text = "";
            lbl_I.Text = "0";
            lbl_S.Text = "0";
            lbl_E.Text = "0";
            lbl_R.Text = "0";
            lbl_IEN.Text = "0";
            lbl_FGI.Text = "0";
            lbl_FGO.Text = "0";
            lbl_Micro.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lbl_FGO.Text = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbl_FGI.Text = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Input may come in the form of a single character ( e.g. ' H ' , ' 2 ' , 1 , etc. ) , in which case its ASCII value will be loaded into the accumulator , or in the form of a hexadecimal unsigned integer preceded by 0x ( e.g. ' 0x3 ' , ' 0x5A ' , ' 0xFF ' ) , in which case , the hexadecimal value will be loaded into the accumulator .", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void assembleAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssembleCode();
        }
    }
}