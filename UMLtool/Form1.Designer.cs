namespace UMLtool
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbFieldStatic = new System.Windows.Forms.CheckBox();
            this.rtbComment = new System.Windows.Forms.RichTextBox();
            this.tbField = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.rbClass = new System.Windows.Forms.RadioButton();
            this.rbAbsclass = new System.Windows.Forms.RadioButton();
            this.rbInterface = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMethodAbs = new System.Windows.Forms.CheckBox();
            this.cbMethodStatic = new System.Windows.Forms.CheckBox();
            this.tbMethod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbGen = new System.Windows.Forms.RadioButton();
            this.rbAggre = new System.Windows.Forms.RadioButton();
            this.rbRel = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRelName = new System.Windows.Forms.TextBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.rbComment = new System.Windows.Forms.RadioButton();
            this.btFieldDel = new System.Windows.Forms.Button();
            this.btMethodDel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新規作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上書き保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画像ファイル生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.java生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.javaＵＭＬToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.font設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herupuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.マニアルの表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btTrackBarInit = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btCommentFont = new System.Windows.Forms.Button();
            this.btInherit = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbFcopy = new System.Windows.Forms.TextBox();
            this.tbMcopy = new System.Windows.Forms.TextBox();
            this.cbajust = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // cbFieldStatic
            // 
            this.cbFieldStatic.AutoSize = true;
            this.cbFieldStatic.Location = new System.Drawing.Point(12, 171);
            this.cbFieldStatic.Name = "cbFieldStatic";
            this.cbFieldStatic.Size = new System.Drawing.Size(97, 28);
            this.cbFieldStatic.TabIndex = 3;
            this.cbFieldStatic.Text = "static";
            this.cbFieldStatic.UseVisualStyleBackColor = true;
            this.cbFieldStatic.CheckedChanged += new System.EventHandler(this.cbFieldStatic_CheckedChanged);
            // 
            // rtbComment
            // 
            this.rtbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbComment.Location = new System.Drawing.Point(8, 429);
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.Size = new System.Drawing.Size(366, 20);
            this.rtbComment.TabIndex = 8;
            this.rtbComment.Text = "";
            this.rtbComment.TextChanged += new System.EventHandler(this.rtbComment_TextChanged);
            // 
            // tbField
            // 
            this.tbField.Location = new System.Drawing.Point(7, 205);
            this.tbField.Name = "tbField";
            this.tbField.Size = new System.Drawing.Size(371, 31);
            this.tbField.TabIndex = 9;
            this.tbField.TextChanged += new System.EventHandler(this.tbField_TextChanged);
            this.tbField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbField_KeyDown);
            this.tbField.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbField_PreviewKeyDown);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(166, 47);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(212, 31);
            this.tbName.TabIndex = 10;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            this.tbName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbName_PreviewKeyDown);
            // 
            // rbClass
            // 
            this.rbClass.AutoSize = true;
            this.rbClass.Location = new System.Drawing.Point(8, 16);
            this.rbClass.Name = "rbClass";
            this.rbClass.Size = new System.Drawing.Size(91, 28);
            this.rbClass.TabIndex = 11;
            this.rbClass.TabStop = true;
            this.rbClass.Text = "class";
            this.rbClass.UseVisualStyleBackColor = true;
            this.rbClass.CheckedChanged += new System.EventHandler(this.rbClass_CheckedChanged);
            // 
            // rbAbsclass
            // 
            this.rbAbsclass.AutoSize = true;
            this.rbAbsclass.Location = new System.Drawing.Point(7, 50);
            this.rbAbsclass.Name = "rbAbsclass";
            this.rbAbsclass.Size = new System.Drawing.Size(137, 28);
            this.rbAbsclass.TabIndex = 12;
            this.rbAbsclass.TabStop = true;
            this.rbAbsclass.Text = "abs-class";
            this.rbAbsclass.UseVisualStyleBackColor = true;
            this.rbAbsclass.CheckedChanged += new System.EventHandler(this.rbAbsclass_CheckedChanged);
            // 
            // rbInterface
            // 
            this.rbInterface.AutoSize = true;
            this.rbInterface.Location = new System.Drawing.Point(8, 84);
            this.rbInterface.Name = "rbInterface";
            this.rbInterface.Size = new System.Drawing.Size(128, 28);
            this.rbInterface.TabIndex = 13;
            this.rbInterface.TabStop = true;
            this.rbInterface.Text = "interface";
            this.rbInterface.UseVisualStyleBackColor = true;
            this.rbInterface.CheckedChanged += new System.EventHandler(this.rbInterface_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(173, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 30);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name";
            // 
            // cbMethodAbs
            // 
            this.cbMethodAbs.AutoSize = true;
            this.cbMethodAbs.Location = new System.Drawing.Point(8, 303);
            this.cbMethodAbs.Name = "cbMethodAbs";
            this.cbMethodAbs.Size = new System.Drawing.Size(123, 28);
            this.cbMethodAbs.TabIndex = 15;
            this.cbMethodAbs.Text = "abstract";
            this.cbMethodAbs.UseVisualStyleBackColor = true;
            this.cbMethodAbs.CheckedChanged += new System.EventHandler(this.cbMethodAbs_CheckedChanged);
            // 
            // cbMethodStatic
            // 
            this.cbMethodStatic.AutoSize = true;
            this.cbMethodStatic.Location = new System.Drawing.Point(150, 303);
            this.cbMethodStatic.Name = "cbMethodStatic";
            this.cbMethodStatic.Size = new System.Drawing.Size(97, 28);
            this.cbMethodStatic.TabIndex = 16;
            this.cbMethodStatic.Text = "static";
            this.cbMethodStatic.UseVisualStyleBackColor = true;
            this.cbMethodStatic.CheckedChanged += new System.EventHandler(this.cbMethodStatic_CheckedChanged);
            // 
            // tbMethod
            // 
            this.tbMethod.Location = new System.Drawing.Point(7, 343);
            this.tbMethod.Name = "tbMethod";
            this.tbMethod.Size = new System.Drawing.Size(371, 31);
            this.tbMethod.TabIndex = 17;
            this.tbMethod.TextChanged += new System.EventHandler(this.tbMethod_TextChanged);
            this.tbMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMethod_KeyDown);
            this.tbMethod.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbMethod_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(7, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 30);
            this.label2.TabIndex = 18;
            this.label2.Text = "Fields";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(8, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 30);
            this.label3.TabIndex = 19;
            this.label3.Text = "Methods";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(7, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 30);
            this.label4.TabIndex = 25;
            this.label4.Text = "Comment";
            // 
            // rbGen
            // 
            this.rbGen.AutoSize = true;
            this.rbGen.Location = new System.Drawing.Point(22, 30);
            this.rbGen.Name = "rbGen";
            this.rbGen.Size = new System.Drawing.Size(74, 34);
            this.rbGen.TabIndex = 27;
            this.rbGen.TabStop = true;
            this.rbGen.Text = "△";
            this.rbGen.UseVisualStyleBackColor = true;
            // 
            // rbAggre
            // 
            this.rbAggre.AutoSize = true;
            this.rbAggre.Location = new System.Drawing.Point(143, 30);
            this.rbAggre.Name = "rbAggre";
            this.rbAggre.Size = new System.Drawing.Size(74, 34);
            this.rbAggre.TabIndex = 28;
            this.rbAggre.TabStop = true;
            this.rbAggre.Text = "◇";
            this.rbAggre.UseVisualStyleBackColor = true;
            this.rbAggre.CheckedChanged += new System.EventHandler(this.rbAggre_CheckedChanged);
            // 
            // rbRel
            // 
            this.rbRel.AutoSize = true;
            this.rbRel.Location = new System.Drawing.Point(261, 30);
            this.rbRel.Name = "rbRel";
            this.rbRel.Size = new System.Drawing.Size(74, 34);
            this.rbRel.TabIndex = 29;
            this.rbRel.TabStop = true;
            this.rbRel.Text = "→";
            this.rbRel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.groupBox1.Controls.Add(this.rbGen);
            this.groupBox1.Controls.Add(this.rbRel);
            this.groupBox1.Controls.Add(this.rbAggre);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(8, 456);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 71);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rel Among Classes";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 535);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 24);
            this.label5.TabIndex = 31;
            this.label5.Text = "Name";
            this.label5.Visible = false;
            // 
            // tbRelName
            // 
            this.tbRelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbRelName.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbRelName.Location = new System.Drawing.Point(82, 528);
            this.tbRelName.Name = "tbRelName";
            this.tbRelName.Size = new System.Drawing.Size(138, 36);
            this.tbRelName.TabIndex = 32;
            this.tbRelName.Visible = false;
            this.tbRelName.TextChanged += new System.EventHandler(this.tbRelName_TextChanged);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.BackColor = System.Drawing.Color.Red;
            this.btDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btDelete.Location = new System.Drawing.Point(12, 585);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(105, 50);
            this.btDelete.TabIndex = 34;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // rbComment
            // 
            this.rbComment.AutoSize = true;
            this.rbComment.Location = new System.Drawing.Point(166, 95);
            this.rbComment.Name = "rbComment";
            this.rbComment.Size = new System.Drawing.Size(133, 28);
            this.rbComment.TabIndex = 35;
            this.rbComment.TabStop = true;
            this.rbComment.Text = "comment";
            this.rbComment.UseVisualStyleBackColor = true;
            // 
            // btFieldDel
            // 
            this.btFieldDel.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btFieldDel.ForeColor = System.Drawing.Color.White;
            this.btFieldDel.Location = new System.Drawing.Point(295, 148);
            this.btFieldDel.Name = "btFieldDel";
            this.btFieldDel.Size = new System.Drawing.Size(83, 42);
            this.btFieldDel.TabIndex = 36;
            this.btFieldDel.Text = "削除";
            this.btFieldDel.UseVisualStyleBackColor = false;
            this.btFieldDel.Click += new System.EventHandler(this.btFieldDel_Click);
            // 
            // btMethodDel
            // 
            this.btMethodDel.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btMethodDel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btMethodDel.Location = new System.Drawing.Point(178, 249);
            this.btMethodDel.Name = "btMethodDel";
            this.btMethodDel.Size = new System.Drawing.Size(96, 42);
            this.btMethodDel.TabIndex = 37;
            this.btMethodDel.Text = "削除";
            this.btMethodDel.UseVisualStyleBackColor = false;
            this.btMethodDel.Click += new System.EventHandler(this.btMethodDel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.herupuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1467, 38);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規作成ToolStripMenuItem,
            this.開くToolStripMenuItem,
            this.上書き保存ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.画像ファイル生成ToolStripMenuItem,
            this.java生成ToolStripMenuItem,
            this.javaＵＭＬToolStripMenuItem,
            this.font設定ToolStripMenuItem,
            this.閉じるToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(128, 34);
            this.ファイルToolStripMenuItem.Text = "ファイル(F)";
            // 
            // 新規作成ToolStripMenuItem
            // 
            this.新規作成ToolStripMenuItem.Name = "新規作成ToolStripMenuItem";
            this.新規作成ToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.新規作成ToolStripMenuItem.Text = "新規作成";
            this.新規作成ToolStripMenuItem.Click += new System.EventHandler(this.新規作成ToolStripMenuItem_Click);
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            this.開くToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.開くToolStripMenuItem.Text = "開く";
            this.開くToolStripMenuItem.Click += new System.EventHandler(this.開くToolStripMenuItem_Click);
            // 
            // 上書き保存ToolStripMenuItem
            // 
            this.上書き保存ToolStripMenuItem.Name = "上書き保存ToolStripMenuItem";
            this.上書き保存ToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.上書き保存ToolStripMenuItem.Text = "上書き保存";
            this.上書き保存ToolStripMenuItem.Click += new System.EventHandler(this.上書き保存ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.保存ToolStripMenuItem.Text = "名前を付けて保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 画像ファイル生成ToolStripMenuItem
            // 
            this.画像ファイル生成ToolStripMenuItem.Name = "画像ファイル生成ToolStripMenuItem";
            this.画像ファイル生成ToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.画像ファイル生成ToolStripMenuItem.Text = "画像ファイル生成";
            this.画像ファイル生成ToolStripMenuItem.Click += new System.EventHandler(this.画像ファイル生成ToolStripMenuItem_Click);
            // 
            // java生成ToolStripMenuItem
            // 
            this.java生成ToolStripMenuItem.Name = "java生成ToolStripMenuItem";
            this.java生成ToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.java生成ToolStripMenuItem.Text = "UML→Java生成";
            this.java生成ToolStripMenuItem.Click += new System.EventHandler(this.java生成ToolStripMenuItem_Click);
            // 
            // javaＵＭＬToolStripMenuItem
            // 
            this.javaＵＭＬToolStripMenuItem.Name = "javaＵＭＬToolStripMenuItem";
            this.javaＵＭＬToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.javaＵＭＬToolStripMenuItem.Text = "Java →UML生成";
            this.javaＵＭＬToolStripMenuItem.Click += new System.EventHandler(this.javaＵＭＬToolStripMenuItem_Click);
            // 
            // font設定ToolStripMenuItem
            // 
            this.font設定ToolStripMenuItem.Name = "font設定ToolStripMenuItem";
            this.font設定ToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.font設定ToolStripMenuItem.Text = "Font設定";
            this.font設定ToolStripMenuItem.Click += new System.EventHandler(this.font設定ToolStripMenuItem_Click);
            // 
            // 閉じるToolStripMenuItem
            // 
            this.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem";
            this.閉じるToolStripMenuItem.Size = new System.Drawing.Size(269, 34);
            this.閉じるToolStripMenuItem.Text = "閉じる";
            this.閉じるToolStripMenuItem.Click += new System.EventHandler(this.閉じるToolStripMenuItem_Click);
            // 
            // herupuToolStripMenuItem
            // 
            this.herupuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.マニアルの表示ToolStripMenuItem});
            this.herupuToolStripMenuItem.Name = "herupuToolStripMenuItem";
            this.herupuToolStripMenuItem.Size = new System.Drawing.Size(155, 34);
            this.herupuToolStripMenuItem.Text = "ヘルプ（Ｈ）";
            // 
            // マニアルの表示ToolStripMenuItem
            // 
            this.マニアルの表示ToolStripMenuItem.Name = "マニアルの表示ToolStripMenuItem";
            this.マニアルの表示ToolStripMenuItem.Size = new System.Drawing.Size(228, 34);
            this.マニアルの表示ToolStripMenuItem.Text = "マニアルの表示";
            this.マニアルの表示ToolStripMenuItem.Click += new System.EventHandler(this.マニアルの表示ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar1.BackColor = System.Drawing.Color.LightYellow;
            this.trackBar1.Location = new System.Drawing.Point(125, 581);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(159, 90);
            this.trackBar1.TabIndex = 39;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // btTrackBarInit
            // 
            this.btTrackBarInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btTrackBarInit.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btTrackBarInit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btTrackBarInit.Location = new System.Drawing.Point(295, 590);
            this.btTrackBarInit.Name = "btTrackBarInit";
            this.btTrackBarInit.Size = new System.Drawing.Size(75, 40);
            this.btTrackBarInit.TabIndex = 40;
            this.btTrackBarInit.Text = "ORG";
            this.btTrackBarInit.UseVisualStyleBackColor = false;
            this.btTrackBarInit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCommentFont
            // 
            this.btCommentFont.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btCommentFont.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btCommentFont.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btCommentFont.Location = new System.Drawing.Point(290, 383);
            this.btCommentFont.Name = "btCommentFont";
            this.btCommentFont.Size = new System.Drawing.Size(88, 43);
            this.btCommentFont.TabIndex = 41;
            this.btCommentFont.Text = "font";
            this.btCommentFont.UseVisualStyleBackColor = false;
            this.btCommentFont.Click += new System.EventHandler(this.button2_Click);
            // 
            // btInherit
            // 
            this.btInherit.BackColor = System.Drawing.Color.Gold;
            this.btInherit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btInherit.Location = new System.Drawing.Point(289, 249);
            this.btInherit.Name = "btInherit";
            this.btInherit.Size = new System.Drawing.Size(88, 41);
            this.btInherit.TabIndex = 42;
            this.btInherit.Text = "継承";
            this.btInherit.UseVisualStyleBackColor = false;
            this.btInherit.Click += new System.EventHandler(this.btInherit_Click);
            // 
            // tbFcopy
            // 
            this.tbFcopy.Location = new System.Drawing.Point(100, 128);
            this.tbFcopy.Name = "tbFcopy";
            this.tbFcopy.Size = new System.Drawing.Size(17, 31);
            this.tbFcopy.TabIndex = 43;
            this.tbFcopy.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbFcopy_PreviewKeyDown);
            // 
            // tbMcopy
            // 
            this.tbMcopy.Location = new System.Drawing.Point(134, 260);
            this.tbMcopy.Name = "tbMcopy";
            this.tbMcopy.Size = new System.Drawing.Size(21, 31);
            this.tbMcopy.TabIndex = 44;
            this.tbMcopy.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbMcopy_PreviewKeyDown);
            // 
            // cbajust
            // 
            this.cbajust.AutoSize = true;
            this.cbajust.Location = new System.Drawing.Point(289, 8);
            this.cbajust.Name = "cbajust";
            this.cbajust.Size = new System.Drawing.Size(89, 28);
            this.cbajust.TabIndex = 45;
            this.cbajust.Text = "ajust";
            this.cbajust.UseVisualStyleBackColor = true;
            this.cbajust.CheckedChanged += new System.EventHandler(this.cbajust_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(403, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 643);
            this.panel1.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel2.Controls.Add(this.tbMult);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btTrackBarInit);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.cbajust);
            this.panel2.Controls.Add(this.btDelete);
            this.panel2.Controls.Add(this.tbMcopy);
            this.panel2.Controls.Add(this.tbFcopy);
            this.panel2.Controls.Add(this.tbRelName);
            this.panel2.Controls.Add(this.btInherit);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btCommentFont);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btMethodDel);
            this.panel2.Controls.Add(this.rbClass);
            this.panel2.Controls.Add(this.btFieldDel);
            this.panel2.Controls.Add(this.cbFieldStatic);
            this.panel2.Controls.Add(this.rbComment);
            this.panel2.Controls.Add(this.rtbComment);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbField);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.rbAbsclass);
            this.panel2.Controls.Add(this.tbMethod);
            this.panel2.Controls.Add(this.rbInterface);
            this.panel2.Controls.Add(this.cbMethodStatic);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbMethodAbs);
            this.panel2.Location = new System.Drawing.Point(11, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 643);
            this.panel2.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(231, 535);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 24);
            this.label6.TabIndex = 46;
            this.label6.Text = "Mult";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tbMult
            // 
            this.tbMult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbMult.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbMult.Location = new System.Drawing.Point(293, 528);
            this.tbMult.Name = "tbMult";
            this.tbMult.Size = new System.Drawing.Size(81, 36);
            this.tbMult.TabIndex = 47;
            this.tbMult.Text = "0..*";
            this.tbMult.Visible = false;
            this.tbMult.TextChanged += new System.EventHandler(this.tbMult_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 956);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UML Class Diagram";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbFieldStatic;
        private System.Windows.Forms.RichTextBox rtbComment;
        private System.Windows.Forms.TextBox tbField;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.RadioButton rbClass;
        private System.Windows.Forms.RadioButton rbAbsclass;
        private System.Windows.Forms.RadioButton rbInterface;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbMethodAbs;
        private System.Windows.Forms.CheckBox cbMethodStatic;
        private System.Windows.Forms.TextBox tbMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbGen;
        private System.Windows.Forms.RadioButton rbAggre;
        private System.Windows.Forms.RadioButton rbRel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRelName;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.RadioButton rbComment;
        private System.Windows.Forms.Button btFieldDel;
        private System.Windows.Forms.Button btMethodDel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新規作成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem java生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem javaＵＭＬToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 閉じるToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btTrackBarInit;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btCommentFont;
        private System.Windows.Forms.ToolStripMenuItem 画像ファイル生成ToolStripMenuItem;
        private System.Windows.Forms.Button btInherit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem font設定ToolStripMenuItem;
        private System.Windows.Forms.TextBox tbFcopy;
        private System.Windows.Forms.TextBox tbMcopy;
        private System.Windows.Forms.ToolStripMenuItem 上書き保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herupuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem マニアルの表示ToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbajust;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbMult;
        private System.Windows.Forms.Label label6;
    }
}

