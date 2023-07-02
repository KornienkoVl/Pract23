namespace Pract23
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MLifeNum = new System.Windows.Forms.Label();
            this.MEnergyNum = new System.Windows.Forms.Label();
            this.MEnergy = new System.Windows.Forms.Label();
            this.MLife = new System.Windows.Forms.Label();
            this.TypeName = new System.Windows.Forms.Label();
            this.kolWolf = new System.Windows.Forms.Label();
            this.kolSheep = new System.Windows.Forms.Label();
            this.kolPlant = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numWolfSpeed = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numSheepSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numPlantSpeed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.numericDensity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericRes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWolfSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSheepSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlantSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.kolWolf);
            this.splitContainer1.Panel1.Controls.Add(this.kolSheep);
            this.splitContainer1.Panel1.Controls.Add(this.kolPlant);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.numWolfSpeed);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.numSheepSpeed);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.numPlantSpeed);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStop);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStart);
            this.splitContainer1.Panel1.Controls.Add(this.numericDensity);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.numericRes);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(975, 576);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(11, 549);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "[ПИ-11] Корниенко Владислав";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MLifeNum);
            this.groupBox1.Controls.Add(this.MEnergyNum);
            this.groupBox1.Controls.Add(this.MEnergy);
            this.groupBox1.Controls.Add(this.MLife);
            this.groupBox1.Controls.Add(this.TypeName);
            this.groupBox1.Location = new System.Drawing.Point(6, 382);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Наведите мышь на существо";
            // 
            // MLifeNum
            // 
            this.MLifeNum.AutoSize = true;
            this.MLifeNum.Location = new System.Drawing.Point(84, 73);
            this.MLifeNum.Name = "MLifeNum";
            this.MLifeNum.Size = new System.Drawing.Size(0, 13);
            this.MLifeNum.TabIndex = 4;
            // 
            // MEnergyNum
            // 
            this.MEnergyNum.AutoSize = true;
            this.MEnergyNum.Location = new System.Drawing.Point(84, 48);
            this.MEnergyNum.Name = "MEnergyNum";
            this.MEnergyNum.Size = new System.Drawing.Size(0, 13);
            this.MEnergyNum.TabIndex = 3;
            // 
            // MEnergy
            // 
            this.MEnergy.AutoSize = true;
            this.MEnergy.Location = new System.Drawing.Point(7, 48);
            this.MEnergy.Name = "MEnergy";
            this.MEnergy.Size = new System.Drawing.Size(52, 13);
            this.MEnergy.TabIndex = 2;
            this.MEnergy.Text = "Энергия:";
            // 
            // MLife
            // 
            this.MLife.AutoSize = true;
            this.MLife.Location = new System.Drawing.Point(7, 73);
            this.MLife.Name = "MLife";
            this.MLife.Size = new System.Drawing.Size(78, 13);
            this.MLife.TabIndex = 1;
            this.MLife.Text = "Время жизни:";
            // 
            // TypeName
            // 
            this.TypeName.AutoSize = true;
            this.TypeName.Location = new System.Drawing.Point(7, 20);
            this.TypeName.Name = "TypeName";
            this.TypeName.Size = new System.Drawing.Size(37, 13);
            this.TypeName.TabIndex = 0;
            this.TypeName.Text = "Пусто";
            // 
            // kolWolf
            // 
            this.kolWolf.AutoSize = true;
            this.kolWolf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kolWolf.Location = new System.Drawing.Point(132, 351);
            this.kolWolf.Name = "kolWolf";
            this.kolWolf.Size = new System.Drawing.Size(15, 15);
            this.kolWolf.TabIndex = 16;
            this.kolWolf.Text = "0";
            // 
            // kolSheep
            // 
            this.kolSheep.AutoSize = true;
            this.kolSheep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kolSheep.Location = new System.Drawing.Point(132, 322);
            this.kolSheep.Name = "kolSheep";
            this.kolSheep.Size = new System.Drawing.Size(15, 15);
            this.kolSheep.TabIndex = 15;
            this.kolSheep.Text = "0";
            // 
            // kolPlant
            // 
            this.kolPlant.AutoSize = true;
            this.kolPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kolPlant.Location = new System.Drawing.Point(132, 293);
            this.kolPlant.Name = "kolPlant";
            this.kolPlant.Size = new System.Drawing.Size(15, 15);
            this.kolPlant.TabIndex = 14;
            this.kolPlant.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Crimson;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Кол-во волков:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Кол-во овец:";
            // 
            // numWolfSpeed
            // 
            this.numWolfSpeed.Location = new System.Drawing.Point(50, 188);
            this.numWolfSpeed.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numWolfSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWolfSpeed.Name = "numWolfSpeed";
            this.numWolfSpeed.Size = new System.Drawing.Size(120, 20);
            this.numWolfSpeed.TabIndex = 11;
            this.numWolfSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWolfSpeed.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(10, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Скорость размножения волков";
            // 
            // numSheepSpeed
            // 
            this.numSheepSpeed.Location = new System.Drawing.Point(50, 149);
            this.numSheepSpeed.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numSheepSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSheepSpeed.Name = "numSheepSpeed";
            this.numSheepSpeed.Size = new System.Drawing.Size(120, 20);
            this.numSheepSpeed.TabIndex = 9;
            this.numSheepSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSheepSpeed.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(10, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Скорость размножения овец";
            // 
            // numPlantSpeed
            // 
            this.numPlantSpeed.Location = new System.Drawing.Point(50, 110);
            this.numPlantSpeed.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPlantSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPlantSpeed.Name = "numPlantSpeed";
            this.numPlantSpeed.Size = new System.Drawing.Size(120, 20);
            this.numPlantSpeed.TabIndex = 7;
            this.numPlantSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPlantSpeed.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(10, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Скорость размножения растений";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.YellowGreen;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Кол-во растений:";
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStop.Location = new System.Drawing.Point(50, 252);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(120, 23);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(50, 223);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(120, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Начать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // numericDensity
            // 
            this.numericDensity.Location = new System.Drawing.Point(50, 71);
            this.numericDensity.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericDensity.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericDensity.Name = "numericDensity";
            this.numericDensity.Size = new System.Drawing.Size(120, 20);
            this.numericDensity.TabIndex = 4;
            this.numericDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericDensity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Плотность появления";
            // 
            // numericRes
            // 
            this.numericRes.Location = new System.Drawing.Point(50, 32);
            this.numericRes.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericRes.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericRes.Name = "numericRes";
            this.numericRes.Size = new System.Drawing.Size(120, 20);
            this.numericRes.TabIndex = 2;
            this.numericRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericRes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Размер существ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(739, 572);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 576);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Замкнутая экосистема";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWolfSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSheepSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlantSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown numericRes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numericDensity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numWolfSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numSheepSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPlantSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label kolWolf;
        private System.Windows.Forms.Label kolSheep;
        private System.Windows.Forms.Label kolPlant;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TypeName;
        private System.Windows.Forms.Label MLifeNum;
        private System.Windows.Forms.Label MEnergyNum;
        private System.Windows.Forms.Label MEnergy;
        private System.Windows.Forms.Label MLife;
        private System.Windows.Forms.Label label9;
    }
}

