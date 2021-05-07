
namespace ExoticOption
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fontDialog2 = new System.Windows.Forms.FontDialog();
            this.checkBox_IsCall = new System.Windows.Forms.CheckBox();
            this.checkBox_Ant = new System.Windows.Forms.CheckBox();
            this.checkBox_CV = new System.Windows.Forms.CheckBox();
            this.checkBox_MT = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.textBox_OptionPrice = new System.Windows.Forms.TextBox();
            this.textBox_Delta = new System.Windows.Forms.TextBox();
            this.textBox_Gamma = new System.Windows.Forms.TextBox();
            this.textBox_Theta = new System.Windows.Forms.TextBox();
            this.textBox_Vega = new System.Windows.Forms.TextBox();
            this.textBox_Rho = new System.Windows.Forms.TextBox();
            this.textBox_Std = new System.Windows.Forms.TextBox();
            this.label_bar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Range = new System.Windows.Forms.CheckBox();
            this.LookBack = new System.Windows.Forms.CheckBox();
            this.Asian = new System.Windows.Forms.CheckBox();
            this.EuropeanOption = new System.Windows.Forms.CheckBox();
            this.Digital = new System.Windows.Forms.CheckBox();
            this.checkBox_Barrier = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Trials = new System.Windows.Forms.TextBox();
            this.textBox_Sigma = new System.Windows.Forms.TextBox();
            this.textBox_R = new System.Windows.Forms.TextBox();
            this.textBox_K = new System.Windows.Forms.TextBox();
            this.textBox_S = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Steps = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_T = new System.Windows.Forms.TextBox();
            this.textBox_Rebate = new System.Windows.Forms.TextBox();
            this.textBox_Barrier = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_IsCall
            // 
            this.checkBox_IsCall.AutoSize = true;
            this.checkBox_IsCall.Location = new System.Drawing.Point(277, 25);
            this.checkBox_IsCall.Name = "checkBox_IsCall";
            this.checkBox_IsCall.Size = new System.Drawing.Size(88, 22);
            this.checkBox_IsCall.TabIndex = 9;
            this.checkBox_IsCall.Text = "IsCall";
            this.checkBox_IsCall.UseVisualStyleBackColor = true;
            // 
            // checkBox_Ant
            // 
            this.checkBox_Ant.AutoSize = true;
            this.checkBox_Ant.Location = new System.Drawing.Point(277, 69);
            this.checkBox_Ant.Name = "checkBox_Ant";
            this.checkBox_Ant.Size = new System.Drawing.Size(142, 22);
            this.checkBox_Ant.TabIndex = 10;
            this.checkBox_Ant.Text = "IsAntithetic";
            this.checkBox_Ant.UseVisualStyleBackColor = true;
            // 
            // checkBox_CV
            // 
            this.checkBox_CV.AutoSize = true;
            this.checkBox_CV.Location = new System.Drawing.Point(277, 110);
            this.checkBox_CV.Name = "checkBox_CV";
            this.checkBox_CV.Size = new System.Drawing.Size(187, 22);
            this.checkBox_CV.TabIndex = 11;
            this.checkBox_CV.Text = "IsControlVariance";
            this.checkBox_CV.UseVisualStyleBackColor = true;
            // 
            // checkBox_MT
            // 
            this.checkBox_MT.AutoSize = true;
            this.checkBox_MT.Location = new System.Drawing.Point(277, 148);
            this.checkBox_MT.Name = "checkBox_MT";
            this.checkBox_MT.Size = new System.Drawing.Size(160, 22);
            this.checkBox_MT.TabIndex = 12;
            this.checkBox_MT.Text = "Multithreading";
            this.checkBox_MT.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(246, 295);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(246, 21);
            this.progressBar1.TabIndex = 13;
            // 
            // textBox_time
            // 
            this.textBox_time.Location = new System.Drawing.Point(190, 345);
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.Size = new System.Drawing.Size(100, 28);
            this.textBox_time.TabIndex = 14;
            // 
            // textBox_OptionPrice
            // 
            this.textBox_OptionPrice.Location = new System.Drawing.Point(557, 48);
            this.textBox_OptionPrice.Name = "textBox_OptionPrice";
            this.textBox_OptionPrice.Size = new System.Drawing.Size(100, 28);
            this.textBox_OptionPrice.TabIndex = 15;
            // 
            // textBox_Delta
            // 
            this.textBox_Delta.Location = new System.Drawing.Point(557, 106);
            this.textBox_Delta.Name = "textBox_Delta";
            this.textBox_Delta.Size = new System.Drawing.Size(100, 28);
            this.textBox_Delta.TabIndex = 16;
            // 
            // textBox_Gamma
            // 
            this.textBox_Gamma.Location = new System.Drawing.Point(557, 166);
            this.textBox_Gamma.Name = "textBox_Gamma";
            this.textBox_Gamma.Size = new System.Drawing.Size(100, 28);
            this.textBox_Gamma.TabIndex = 17;
            // 
            // textBox_Theta
            // 
            this.textBox_Theta.Location = new System.Drawing.Point(557, 221);
            this.textBox_Theta.Name = "textBox_Theta";
            this.textBox_Theta.Size = new System.Drawing.Size(100, 28);
            this.textBox_Theta.TabIndex = 18;
            // 
            // textBox_Vega
            // 
            this.textBox_Vega.Location = new System.Drawing.Point(557, 281);
            this.textBox_Vega.Name = "textBox_Vega";
            this.textBox_Vega.Size = new System.Drawing.Size(100, 28);
            this.textBox_Vega.TabIndex = 19;
            // 
            // textBox_Rho
            // 
            this.textBox_Rho.Location = new System.Drawing.Point(557, 339);
            this.textBox_Rho.Name = "textBox_Rho";
            this.textBox_Rho.Size = new System.Drawing.Size(100, 28);
            this.textBox_Rho.TabIndex = 20;
            // 
            // textBox_Std
            // 
            this.textBox_Std.Location = new System.Drawing.Point(557, 395);
            this.textBox_Std.Name = "textBox_Std";
            this.textBox_Std.Size = new System.Drawing.Size(100, 28);
            this.textBox_Std.TabIndex = 21;
            // 
            // label_bar
            // 
            this.label_bar.Location = new System.Drawing.Point(28, 345);
            this.label_bar.Name = "label_bar";
            this.label_bar.Size = new System.Drawing.Size(100, 28);
            this.label_bar.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 63);
            this.button1.TabIndex = 23;
            this.button1.Text = "Simulation!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textBox_time);
            this.groupBox2.Controls.Add(this.label_bar);
            this.groupBox2.Location = new System.Drawing.Point(202, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 435);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 324);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 18);
            this.label15.TabIndex = 40;
            this.label15.Text = "Core number";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(191, 324);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(134, 18);
            this.label16.TabIndex = 41;
            this.label16.Text = "Operating time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(565, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 33;
            this.label8.Text = "OptionPrice";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(565, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 18);
            this.label9.TabIndex = 34;
            this.label9.Text = "Delta";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(565, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 18);
            this.label10.TabIndex = 35;
            this.label10.Text = "Gamma";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(565, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 18);
            this.label11.TabIndex = 36;
            this.label11.Text = "Theta";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(564, 260);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 18);
            this.label12.TabIndex = 37;
            this.label12.Text = "Vega";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(564, 318);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 18);
            this.label13.TabIndex = 38;
            this.label13.Text = "Rho";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(565, 374);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 18);
            this.label14.TabIndex = 39;
            this.label14.Text = "SE";
            // 
            // Range
            // 
            this.Range.AutoSize = true;
            this.Range.Location = new System.Drawing.Point(711, 370);
            this.Range.Name = "Range";
            this.Range.Size = new System.Drawing.Size(79, 22);
            this.Range.TabIndex = 40;
            this.Range.Text = "Range";
            this.Range.UseVisualStyleBackColor = true;
            this.Range.CheckedChanged += new System.EventHandler(this.Range_CheckedChanged);
            // 
            // LookBack
            // 
            this.LookBack.AutoSize = true;
            this.LookBack.Location = new System.Drawing.Point(711, 314);
            this.LookBack.Name = "LookBack";
            this.LookBack.Size = new System.Drawing.Size(106, 22);
            this.LookBack.TabIndex = 41;
            this.LookBack.Text = "LookBack";
            this.LookBack.UseVisualStyleBackColor = true;
            this.LookBack.CheckedChanged += new System.EventHandler(this.LookBack_CheckedChanged);
            // 
            // Asian
            // 
            this.Asian.AutoSize = true;
            this.Asian.Location = new System.Drawing.Point(711, 144);
            this.Asian.Name = "Asian";
            this.Asian.Size = new System.Drawing.Size(79, 22);
            this.Asian.TabIndex = 44;
            this.Asian.Text = "Asian";
            this.Asian.UseVisualStyleBackColor = true;
            // 
            // EuropeanOption
            // 
            this.EuropeanOption.AutoSize = true;
            this.EuropeanOption.Location = new System.Drawing.Point(711, 84);
            this.EuropeanOption.Name = "EuropeanOption";
            this.EuropeanOption.Size = new System.Drawing.Size(160, 22);
            this.EuropeanOption.TabIndex = 45;
            this.EuropeanOption.Text = "EuropeanOption";
            this.EuropeanOption.UseVisualStyleBackColor = true;
            // 
            // Digital
            // 
            this.Digital.AutoSize = true;
            this.Digital.Location = new System.Drawing.Point(711, 200);
            this.Digital.Name = "Digital";
            this.Digital.Size = new System.Drawing.Size(97, 22);
            this.Digital.TabIndex = 47;
            this.Digital.Text = "Digital";
            this.Digital.UseVisualStyleBackColor = true;
            this.Digital.CheckedChanged += new System.EventHandler(this.Digital_CheckedChanged);
            // 
            // checkBox_Barrier
            // 
            this.checkBox_Barrier.AutoSize = true;
            this.checkBox_Barrier.Location = new System.Drawing.Point(711, 256);
            this.checkBox_Barrier.Name = "checkBox_Barrier";
            this.checkBox_Barrier.Size = new System.Drawing.Size(97, 22);
            this.checkBox_Barrier.TabIndex = 48;
            this.checkBox_Barrier.Text = "Barrier";
            this.checkBox_Barrier.UseVisualStyleBackColor = true;
            this.checkBox_Barrier.CheckedChanged += new System.EventHandler(this.checkBox_Barrier_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 18);
            this.label7.TabIndex = 30;
            this.label7.Text = "S";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "K";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 18);
            this.label5.TabIndex = 28;
            this.label5.Text = "R";
            // 
            // textBox_Trials
            // 
            this.textBox_Trials.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox_Trials.Location = new System.Drawing.Point(24, 327);
            this.textBox_Trials.Name = "textBox_Trials";
            this.textBox_Trials.Size = new System.Drawing.Size(63, 28);
            this.textBox_Trials.TabIndex = 8;
            this.textBox_Trials.Text = "10000";
            // 
            // textBox_Sigma
            // 
            this.textBox_Sigma.Location = new System.Drawing.Point(24, 215);
            this.textBox_Sigma.Name = "textBox_Sigma";
            this.textBox_Sigma.Size = new System.Drawing.Size(63, 28);
            this.textBox_Sigma.TabIndex = 3;
            this.textBox_Sigma.Text = "0.5";
            // 
            // textBox_R
            // 
            this.textBox_R.Location = new System.Drawing.Point(24, 157);
            this.textBox_R.Name = "textBox_R";
            this.textBox_R.Size = new System.Drawing.Size(63, 28);
            this.textBox_R.TabIndex = 2;
            this.textBox_R.Text = "0.05";
            // 
            // textBox_K
            // 
            this.textBox_K.Location = new System.Drawing.Point(24, 101);
            this.textBox_K.Name = "textBox_K";
            this.textBox_K.Size = new System.Drawing.Size(63, 28);
            this.textBox_K.TabIndex = 1;
            this.textBox_K.Text = "50";
            // 
            // textBox_S
            // 
            this.textBox_S.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox_S.Location = new System.Drawing.Point(24, 49);
            this.textBox_S.Name = "textBox_S";
            this.textBox_S.Size = new System.Drawing.Size(63, 28);
            this.textBox_S.TabIndex = 0;
            this.textBox_S.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Sigma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "T";
            // 
            // textBox_Steps
            // 
            this.textBox_Steps.Location = new System.Drawing.Point(24, 383);
            this.textBox_Steps.Name = "textBox_Steps";
            this.textBox_Steps.Size = new System.Drawing.Size(63, 28);
            this.textBox_Steps.TabIndex = 6;
            this.textBox_Steps.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 29;
            this.label6.Text = "Steps";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "Trials";
            // 
            // textBox_T
            // 
            this.textBox_T.Location = new System.Drawing.Point(24, 269);
            this.textBox_T.Name = "textBox_T";
            this.textBox_T.Size = new System.Drawing.Size(63, 28);
            this.textBox_T.TabIndex = 4;
            this.textBox_T.Text = "1";
            // 
            // textBox_Rebate
            // 
            this.textBox_Rebate.Enabled = false;
            this.textBox_Rebate.Location = new System.Drawing.Point(124, 49);
            this.textBox_Rebate.Name = "textBox_Rebate";
            this.textBox_Rebate.Size = new System.Drawing.Size(59, 28);
            this.textBox_Rebate.TabIndex = 46;
            // 
            // textBox_Barrier
            // 
            this.textBox_Barrier.Enabled = false;
            this.textBox_Barrier.Location = new System.Drawing.Point(124, 101);
            this.textBox_Barrier.Name = "textBox_Barrier";
            this.textBox_Barrier.Size = new System.Drawing.Size(59, 28);
            this.textBox_Barrier.TabIndex = 48;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(99, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 18);
            this.label17.TabIndex = 49;
            this.label17.Text = "Barriertype";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(121, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 18);
            this.label19.TabIndex = 51;
            this.label19.Text = "Barrier";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(121, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 18);
            this.label18.TabIndex = 50;
            this.label18.Text = "Rebate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBox_Barrier);
            this.groupBox1.Controls.Add(this.textBox_Rebate);
            this.groupBox1.Controls.Add(this.textBox_T);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_Steps);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_S);
            this.groupBox1.Controls.Add(this.textBox_K);
            this.groupBox1.Controls.Add(this.textBox_R);
            this.groupBox1.Controls.Add(this.textBox_Sigma);
            this.groupBox1.Controls.Add(this.textBox_Trials);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 435);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Down and out",
            "Up and out",
            "Down and in",
            "Up and in"});
            this.comboBox1.Location = new System.Drawing.Point(93, 159);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 26);
            this.comboBox1.TabIndex = 49;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(866, 450);
            this.Controls.Add(this.checkBox_Barrier);
            this.Controls.Add(this.Digital);
            this.Controls.Add(this.EuropeanOption);
            this.Controls.Add(this.Asian);
            this.Controls.Add(this.LookBack);
            this.Controls.Add(this.Range);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_Std);
            this.Controls.Add(this.textBox_Rho);
            this.Controls.Add(this.textBox_Vega);
            this.Controls.Add(this.textBox_Theta);
            this.Controls.Add(this.textBox_Gamma);
            this.Controls.Add(this.textBox_Delta);
            this.Controls.Add(this.textBox_OptionPrice);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox_MT);
            this.Controls.Add(this.checkBox_CV);
            this.Controls.Add(this.checkBox_Ant);
            this.Controls.Add(this.checkBox_IsCall);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.FontDialog fontDialog2;
        private System.Windows.Forms.CheckBox checkBox_IsCall;
        private System.Windows.Forms.CheckBox checkBox_Ant;
        private System.Windows.Forms.CheckBox checkBox_CV;
        private System.Windows.Forms.CheckBox checkBox_MT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox_time;
        private System.Windows.Forms.TextBox textBox_OptionPrice;
        private System.Windows.Forms.TextBox textBox_Delta;
        private System.Windows.Forms.TextBox textBox_Gamma;
        private System.Windows.Forms.TextBox textBox_Theta;
        private System.Windows.Forms.TextBox textBox_Vega;
        private System.Windows.Forms.TextBox textBox_Rho;
        private System.Windows.Forms.TextBox textBox_Std;
        private System.Windows.Forms.TextBox label_bar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox Range;
        private System.Windows.Forms.CheckBox LookBack;
        private System.Windows.Forms.CheckBox Asian;
        private System.Windows.Forms.CheckBox EuropeanOption;
        private System.Windows.Forms.CheckBox Digital;
        private System.Windows.Forms.CheckBox checkBox_Barrier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Trials;
        private System.Windows.Forms.TextBox textBox_Sigma;
        private System.Windows.Forms.TextBox textBox_R;
        private System.Windows.Forms.TextBox textBox_K;
        private System.Windows.Forms.TextBox textBox_S;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Steps;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_T;
        private System.Windows.Forms.TextBox textBox_Rebate;
        private System.Windows.Forms.TextBox textBox_Barrier;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

