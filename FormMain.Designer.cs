namespace GenderRecognition
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.importBTN = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ProcessBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkGenderBTN = new Bunifu.Framework.UI.BunifuFlatButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.manualRB = new System.Windows.Forms.RadioButton();
            this.automaticRB = new System.Windows.Forms.RadioButton();
            this.LearnBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.folderRB = new System.Windows.Forms.RadioButton();
            this.importRB = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgSourceFolder = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSourceExcel = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ExportBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_check = new System.Windows.Forms.Label();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sourceFolderBG = new System.ComponentModel.BackgroundWorker();
            this.sourceExcelBG = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.learnMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkGenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSourceFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSourceExcel)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // importBTN
            // 
            this.importBTN.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.importBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.importBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.importBTN.BorderRadius = 0;
            this.importBTN.ButtonText = "   Import";
            this.importBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importBTN.DisabledColor = System.Drawing.Color.Gray;
            this.importBTN.Iconcolor = System.Drawing.Color.Transparent;
            this.importBTN.Iconimage = ((System.Drawing.Image)(resources.GetObject("importBTN.Iconimage")));
            this.importBTN.Iconimage_right = null;
            this.importBTN.Iconimage_right_Selected = null;
            this.importBTN.Iconimage_Selected = null;
            this.importBTN.IconMarginLeft = 0;
            this.importBTN.IconMarginRight = 0;
            this.importBTN.IconRightVisible = true;
            this.importBTN.IconRightZoom = 0D;
            this.importBTN.IconVisible = true;
            this.importBTN.IconZoom = 45D;
            this.importBTN.IsTab = false;
            this.importBTN.Location = new System.Drawing.Point(12, 167);
            this.importBTN.Name = "importBTN";
            this.importBTN.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.importBTN.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.importBTN.OnHoverTextColor = System.Drawing.Color.White;
            this.importBTN.selected = false;
            this.importBTN.Size = new System.Drawing.Size(150, 45);
            this.importBTN.TabIndex = 0;
            this.importBTN.Text = "   Import";
            this.importBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.importBTN.Textcolor = System.Drawing.Color.White;
            this.importBTN.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBTN.Click += new System.EventHandler(this.importBTN_ClickAsync);
            // 
            // ProcessBtn
            // 
            this.ProcessBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ProcessBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ProcessBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProcessBtn.BorderRadius = 0;
            this.ProcessBtn.ButtonText = "   Process";
            this.ProcessBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProcessBtn.DisabledColor = System.Drawing.Color.Gray;
            this.ProcessBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.ProcessBtn.Iconimage = ((System.Drawing.Image)(resources.GetObject("ProcessBtn.Iconimage")));
            this.ProcessBtn.Iconimage_right = null;
            this.ProcessBtn.Iconimage_right_Selected = null;
            this.ProcessBtn.Iconimage_Selected = null;
            this.ProcessBtn.IconMarginLeft = 0;
            this.ProcessBtn.IconMarginRight = 0;
            this.ProcessBtn.IconRightVisible = true;
            this.ProcessBtn.IconRightZoom = 0D;
            this.ProcessBtn.IconVisible = true;
            this.ProcessBtn.IconZoom = 45D;
            this.ProcessBtn.IsTab = false;
            this.ProcessBtn.Location = new System.Drawing.Point(466, 60);
            this.ProcessBtn.Name = "ProcessBtn";
            this.ProcessBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ProcessBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ProcessBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.ProcessBtn.selected = false;
            this.ProcessBtn.Size = new System.Drawing.Size(175, 45);
            this.ProcessBtn.TabIndex = 2;
            this.ProcessBtn.Text = "   Process";
            this.ProcessBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProcessBtn.Textcolor = System.Drawing.Color.White;
            this.ProcessBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessBtn.Visible = false;
            this.ProcessBtn.Click += new System.EventHandler(this.bunifuFlatButton1_ClickAsync);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.checkGenderBTN);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.LearnBtn);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.ProcessBtn);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.importBTN);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 218);
            this.panel2.TabIndex = 6;
            // 
            // checkGenderBTN
            // 
            this.checkGenderBTN.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.checkGenderBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.checkGenderBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkGenderBTN.BorderRadius = 0;
            this.checkGenderBTN.ButtonText = "Batch Check Gender";
            this.checkGenderBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkGenderBTN.DisabledColor = System.Drawing.Color.Gray;
            this.checkGenderBTN.Iconcolor = System.Drawing.Color.Transparent;
            this.checkGenderBTN.Iconimage = ((System.Drawing.Image)(resources.GetObject("checkGenderBTN.Iconimage")));
            this.checkGenderBTN.Iconimage_right = null;
            this.checkGenderBTN.Iconimage_right_Selected = null;
            this.checkGenderBTN.Iconimage_Selected = null;
            this.checkGenderBTN.IconMarginLeft = 0;
            this.checkGenderBTN.IconMarginRight = 0;
            this.checkGenderBTN.IconRightVisible = true;
            this.checkGenderBTN.IconRightZoom = 0D;
            this.checkGenderBTN.IconVisible = true;
            this.checkGenderBTN.IconZoom = 45D;
            this.checkGenderBTN.IsTab = false;
            this.checkGenderBTN.Location = new System.Drawing.Point(276, 167);
            this.checkGenderBTN.Name = "checkGenderBTN";
            this.checkGenderBTN.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.checkGenderBTN.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.checkGenderBTN.OnHoverTextColor = System.Drawing.Color.White;
            this.checkGenderBTN.selected = false;
            this.checkGenderBTN.Size = new System.Drawing.Size(175, 45);
            this.checkGenderBTN.TabIndex = 5;
            this.checkGenderBTN.Text = "Batch Check Gender";
            this.checkGenderBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkGenderBTN.Textcolor = System.Drawing.Color.White;
            this.checkGenderBTN.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkGenderBTN.Click += new System.EventHandler(this.checkGenderBTN_ClickAsync);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.manualRB);
            this.groupBox2.Controls.Add(this.automaticRB);
            this.groupBox2.Location = new System.Drawing.Point(12, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 39);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Method Check Gender";
            // 
            // manualRB
            // 
            this.manualRB.AutoSize = true;
            this.manualRB.Location = new System.Drawing.Point(108, 16);
            this.manualRB.Name = "manualRB";
            this.manualRB.Size = new System.Drawing.Size(60, 17);
            this.manualRB.TabIndex = 1;
            this.manualRB.TabStop = true;
            this.manualRB.Text = "Manual";
            this.manualRB.UseVisualStyleBackColor = true;
            this.manualRB.CheckedChanged += new System.EventHandler(this.manualRB_CheckedChanged);
            // 
            // automaticRB
            // 
            this.automaticRB.AutoSize = true;
            this.automaticRB.Location = new System.Drawing.Point(7, 16);
            this.automaticRB.Name = "automaticRB";
            this.automaticRB.Size = new System.Drawing.Size(72, 17);
            this.automaticRB.TabIndex = 0;
            this.automaticRB.TabStop = true;
            this.automaticRB.Text = "Automatic";
            this.automaticRB.UseVisualStyleBackColor = true;
            this.automaticRB.CheckedChanged += new System.EventHandler(this.automaticRB_CheckedChanged);
            // 
            // LearnBtn
            // 
            this.LearnBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.LearnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.LearnBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LearnBtn.BorderRadius = 0;
            this.LearnBtn.ButtonText = "Refresh";
            this.LearnBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LearnBtn.DisabledColor = System.Drawing.Color.Gray;
            this.LearnBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.LearnBtn.Iconimage = ((System.Drawing.Image)(resources.GetObject("LearnBtn.Iconimage")));
            this.LearnBtn.Iconimage_right = null;
            this.LearnBtn.Iconimage_right_Selected = null;
            this.LearnBtn.Iconimage_Selected = null;
            this.LearnBtn.IconMarginLeft = 0;
            this.LearnBtn.IconMarginRight = 0;
            this.LearnBtn.IconRightVisible = true;
            this.LearnBtn.IconRightZoom = 0D;
            this.LearnBtn.IconVisible = true;
            this.LearnBtn.IconZoom = 45D;
            this.LearnBtn.IsTab = false;
            this.LearnBtn.Location = new System.Drawing.Point(457, 167);
            this.LearnBtn.Name = "LearnBtn";
            this.LearnBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.LearnBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.LearnBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.LearnBtn.selected = false;
            this.LearnBtn.Size = new System.Drawing.Size(175, 45);
            this.LearnBtn.TabIndex = 4;
            this.LearnBtn.Text = "Refresh";
            this.LearnBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LearnBtn.Textcolor = System.Drawing.Color.White;
            this.LearnBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LearnBtn.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaGreen;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(644, 54);
            this.panel4.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.folderRB);
            this.groupBox1.Controls.Add(this.importRB);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 39);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Files";
            // 
            // folderRB
            // 
            this.folderRB.AutoSize = true;
            this.folderRB.Checked = true;
            this.folderRB.Location = new System.Drawing.Point(7, 16);
            this.folderRB.Name = "folderRB";
            this.folderRB.Size = new System.Drawing.Size(54, 17);
            this.folderRB.TabIndex = 1;
            this.folderRB.TabStop = true;
            this.folderRB.Text = "Folder";
            this.folderRB.UseVisualStyleBackColor = true;
            // 
            // importRB
            // 
            this.importRB.AutoSize = true;
            this.importRB.Location = new System.Drawing.Point(108, 16);
            this.importRB.Name = "importRB";
            this.importRB.Size = new System.Drawing.Size(51, 17);
            this.importRB.TabIndex = 0;
            this.importRB.Text = "Excel";
            this.importRB.UseVisualStyleBackColor = true;
            this.importRB.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 313);
            this.panel1.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel5.Controls.Add(this.dgSourceFolder);
            this.panel5.Controls.Add(this.dgSourceExcel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 32);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(644, 229);
            this.panel5.TabIndex = 4;
            // 
            // dgSourceFolder
            // 
            this.dgSourceFolder.AllowUserToAddRows = false;
            this.dgSourceFolder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSourceFolder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column11});
            this.dgSourceFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSourceFolder.Location = new System.Drawing.Point(0, 0);
            this.dgSourceFolder.Name = "dgSourceFolder";
            this.dgSourceFolder.RowTemplate.Height = 172;
            this.dgSourceFolder.Size = new System.Drawing.Size(644, 229);
            this.dgSourceFolder.TabIndex = 9;
            this.dgSourceFolder.Visible = false;
            this.dgSourceFolder.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgSourceFolder_CellMouseDown);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "isChecked";
            this.Column4.HeaderText = "Check";
            this.Column4.Name = "Column4";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "name";
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Image";
            this.Column2.HeaderText = "Image";
            this.Column2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 142;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "gender";
            this.Column3.HeaderText = "Gender";
            this.Column3.Name = "Column3";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Path";
            this.Column11.HeaderText = "Path";
            this.Column11.Name = "Column11";
            this.Column11.Visible = false;
            // 
            // dgSourceExcel
            // 
            this.dgSourceExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSourceExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column10,
            this.Column9});
            this.dgSourceExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSourceExcel.Location = new System.Drawing.Point(0, 0);
            this.dgSourceExcel.Name = "dgSourceExcel";
            this.dgSourceExcel.RowTemplate.Height = 172;
            this.dgSourceExcel.Size = new System.Drawing.Size(644, 229);
            this.dgSourceExcel.TabIndex = 8;
            this.dgSourceExcel.Visible = false;
            this.dgSourceExcel.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgSourceExcel_CellMouseDown);
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "isChecked";
            this.Column5.HeaderText = "Check";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "name";
            this.Column6.HeaderText = "Name";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Update";
            this.Column7.HeaderText = "Update Time";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "URL";
            this.Column8.HeaderText = "URL Image";
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Image";
            this.Column10.HeaderText = "Image";
            this.Column10.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column10.Name = "Column10";
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column10.Width = 142;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "gender";
            this.Column9.HeaderText = "Gender";
            this.Column9.Name = "Column9";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ExportBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 261);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(644, 52);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ExportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ExportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExportBtn.BorderRadius = 0;
            this.ExportBtn.ButtonText = "   Export";
            this.ExportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportBtn.DisabledColor = System.Drawing.Color.Gray;
            this.ExportBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.ExportBtn.Iconimage = ((System.Drawing.Image)(resources.GetObject("ExportBtn.Iconimage")));
            this.ExportBtn.Iconimage_right = null;
            this.ExportBtn.Iconimage_right_Selected = null;
            this.ExportBtn.Iconimage_Selected = null;
            this.ExportBtn.IconMarginLeft = 0;
            this.ExportBtn.IconMarginRight = 0;
            this.ExportBtn.IconRightVisible = true;
            this.ExportBtn.IconRightZoom = 0D;
            this.ExportBtn.IconVisible = true;
            this.ExportBtn.IconZoom = 45D;
            this.ExportBtn.IsTab = false;
            this.ExportBtn.Location = new System.Drawing.Point(466, 3);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ExportBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ExportBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.ExportBtn.selected = false;
            this.ExportBtn.Size = new System.Drawing.Size(175, 45);
            this.ExportBtn.TabIndex = 1;
            this.ExportBtn.Text = "   Export";
            this.ExportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportBtn.Textcolor = System.Drawing.Color.White;
            this.ExportBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_check);
            this.panel3.Controls.Add(this.bunifuCheckbox1);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(644, 32);
            this.panel3.TabIndex = 0;
            // 
            // lbl_check
            // 
            this.lbl_check.AutoSize = true;
            this.lbl_check.Location = new System.Drawing.Point(244, 7);
            this.lbl_check.Name = "lbl_check";
            this.lbl_check.Size = new System.Drawing.Size(52, 13);
            this.lbl_check.TabIndex = 3;
            this.lbl_check.Text = "Check All";
            this.lbl_check.Click += new System.EventHandler(this.lbl_check_Click);
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.Checked = false;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.bunifuCheckbox1.ForeColor = System.Drawing.Color.White;
            this.bunifuCheckbox1.Location = new System.Drawing.Point(218, 5);
            this.bunifuCheckbox1.Name = "bunifuCheckbox1";
            this.bunifuCheckbox1.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox1.TabIndex = 2;
            this.bunifuCheckbox1.OnChange += new System.EventHandler(this.bunifuCheckbox1_OnChange);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All",
            "Pria",
            "Wanita",
            "Kelompok",
            "N/A"});
            this.comboBox1.Location = new System.Drawing.Point(60, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sort By";
            // 
            // sourceFolderBG
            // 
            this.sourceFolderBG.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.sourceFolderBG.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // sourceExcelBG
            // 
            this.sourceExcelBG.WorkerReportsProgress = true;
            this.sourceExcelBG.WorkerSupportsCancellation = true;
            this.sourceExcelBG.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sourceExcelBG_DoWorkAsync);
            this.sourceExcelBG.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sourceExcelBG_RunWorkerCompleted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.learnMachineToolStripMenuItem,
            this.checkGenderToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // learnMachineToolStripMenuItem
            // 
            this.learnMachineToolStripMenuItem.Name = "learnMachineToolStripMenuItem";
            this.learnMachineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.learnMachineToolStripMenuItem.Text = "Learn Machine";
            this.learnMachineToolStripMenuItem.Click += new System.EventHandler(this.learnMachineToolStripMenuItem_Click);
            // 
            // checkGenderToolStripMenuItem
            // 
            this.checkGenderToolStripMenuItem.Name = "checkGenderToolStripMenuItem";
            this.checkGenderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.checkGenderToolStripMenuItem.Text = "Check Gender";
            this.checkGenderToolStripMenuItem.Click += new System.EventHandler(this.checkGenderToolStripMenuItem_ClickAsync);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 531);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "LastSeen T.Marie";
            this.Load += new System.EventHandler(this.FormMain_LoadAsync);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSourceFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSourceExcel)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuFlatButton importBTN;
        private Bunifu.Framework.UI.BunifuFlatButton ProcessBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton folderRB;
        private System.Windows.Forms.RadioButton importRB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
        private System.Windows.Forms.Label lbl_check;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker sourceFolderBG;
        private System.ComponentModel.BackgroundWorker sourceExcelBG;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuFlatButton LearnBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem learnMachineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkGenderToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton manualRB;
        private System.Windows.Forms.RadioButton automaticRB;
        private Bunifu.Framework.UI.BunifuFlatButton checkGenderBTN;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgSourceFolder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridView dgSourceExcel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewImageColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Bunifu.Framework.UI.BunifuFlatButton ExportBtn;
    }
}