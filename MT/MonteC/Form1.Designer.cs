
namespace MonteC
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


        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_OptionPrice = new System.Windows.Forms.TextBox();
            this.textBox_S = new System.Windows.Forms.TextBox();
            this.textBox_K = new System.Windows.Forms.TextBox();
            this.textBox_R = new System.Windows.Forms.TextBox();
            this.textBox_Sigma = new System.Windows.Forms.TextBox();
            this.textBox_T = new System.Windows.Forms.TextBox();
            this.textBox_Trials = new System.Windows.Forms.TextBox();
            this.textBox_Steps = new System.Windows.Forms.TextBox();
            this.textBox_Std = new System.Windows.Forms.TextBox();
            this.textBox_Rho = new System.Windows.Forms.TextBox();
            this.textBox_Theta = new System.Windows.Forms.TextBox();
            this.textBox_Vega = new System.Windows.Forms.TextBox();
            this.textBox_Gamma = new System.Windows.Forms.TextBox();
            this.textBox_Delta = new System.Windows.Forms.TextBox();
            this.IsCall = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Ant = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CV = new System.Windows.Forms.CheckBox();
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.MT = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label16 = new System.Windows.Forms.Label();
            this.label_bar = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_OptionPrice
            // 
            this.textBox_OptionPrice.Location = new System.Drawing.Point(578, 50);
            this.textBox_OptionPrice.Name = "textBox_OptionPrice";
            this.textBox_OptionPrice.Size = new System.Drawing.Size(100, 28);
            this.textBox_OptionPrice.TabIndex = 0;
            this.textBox_OptionPrice.TextChanged += new System.EventHandler(this.textBox_OptionPrice_TextChanged);
            // 
            // textBox_S
            // 
            this.textBox_S.Location = new System.Drawing.Point(82, 50);
            this.textBox_S.Name = "textBox_S";
            this.textBox_S.Size = new System.Drawing.Size(100, 28);
            this.textBox_S.TabIndex = 1;
            this.textBox_S.Text = "50";
            // 
            // textBox_K
            // 
            this.textBox_K.Location = new System.Drawing.Point(82, 112);
            this.textBox_K.Name = "textBox_K";
            this.textBox_K.Size = new System.Drawing.Size(100, 28);
            this.textBox_K.TabIndex = 2;
            this.textBox_K.Text = "50";
            // 
            // textBox_R
            // 
            this.textBox_R.Location = new System.Drawing.Point(82, 170);
            this.textBox_R.Name = "textBox_R";
            this.textBox_R.Size = new System.Drawing.Size(100, 28);
            this.textBox_R.TabIndex = 3;
            this.textBox_R.Text = "0.05";
            // 
            // textBox_Sigma
            // 
            this.textBox_Sigma.Location = new System.Drawing.Point(82, 225);
            this.textBox_Sigma.Name = "textBox_Sigma";
            this.textBox_Sigma.Size = new System.Drawing.Size(100, 28);
            this.textBox_Sigma.TabIndex = 4;
            this.textBox_Sigma.Text = "0.5";
            // 
            // textBox_T
            // 
            this.textBox_T.Location = new System.Drawing.Point(82, 278);
            this.textBox_T.Name = "textBox_T";
            this.textBox_T.Size = new System.Drawing.Size(100, 28);
            this.textBox_T.TabIndex = 5;
            this.textBox_T.Text = "1";
            // 
            // textBox_Trials
            // 
            this.textBox_Trials.Location = new System.Drawing.Point(82, 333);
            this.textBox_Trials.Name = "textBox_Trials";
            this.textBox_Trials.Size = new System.Drawing.Size(100, 28);
            this.textBox_Trials.TabIndex = 6;
            this.textBox_Trials.Text = "10000";
            // 
            // textBox_Steps
            // 
            this.textBox_Steps.Location = new System.Drawing.Point(82, 388);
            this.textBox_Steps.Name = "textBox_Steps";
            this.textBox_Steps.Size = new System.Drawing.Size(100, 28);
            this.textBox_Steps.TabIndex = 7;
            this.textBox_Steps.Text = "100";
            // 
            // textBox_Std
            // 
            this.textBox_Std.Location = new System.Drawing.Point(578, 381);
            this.textBox_Std.Name = "textBox_Std";
            this.textBox_Std.Size = new System.Drawing.Size(100, 28);
            this.textBox_Std.TabIndex = 8;
            // 
            // textBox_Rho
            // 
            this.textBox_Rho.Location = new System.Drawing.Point(578, 336);
            this.textBox_Rho.Name = "textBox_Rho";
            this.textBox_Rho.Size = new System.Drawing.Size(100, 28);
            this.textBox_Rho.TabIndex = 9;
            // 
            // textBox_Theta
            // 
            this.textBox_Theta.Location = new System.Drawing.Point(578, 278);
            this.textBox_Theta.Name = "textBox_Theta";
            this.textBox_Theta.Size = new System.Drawing.Size(100, 28);
            this.textBox_Theta.TabIndex = 10;
            // 
            // textBox_Vega
            // 
            this.textBox_Vega.Location = new System.Drawing.Point(578, 228);
            this.textBox_Vega.Name = "textBox_Vega";
            this.textBox_Vega.Size = new System.Drawing.Size(100, 28);
            this.textBox_Vega.TabIndex = 11;
            this.textBox_Vega.TextChanged += new System.EventHandler(this.textBox_Vega_TextChanged);
            // 
            // textBox_Gamma
            // 
            this.textBox_Gamma.Location = new System.Drawing.Point(578, 170);
            this.textBox_Gamma.Name = "textBox_Gamma";
            this.textBox_Gamma.Size = new System.Drawing.Size(100, 28);
            this.textBox_Gamma.TabIndex = 12;
            // 
            // textBox_Delta
            // 
            this.textBox_Delta.Location = new System.Drawing.Point(578, 112);
            this.textBox_Delta.Name = "textBox_Delta";
            this.textBox_Delta.Size = new System.Drawing.Size(100, 28);
            this.textBox_Delta.TabIndex = 13;
            // 
            // IsCall
            // 
            this.IsCall.AutoSize = true;
            this.IsCall.Location = new System.Drawing.Point(303, 56);
            this.IsCall.Name = "IsCall";
            this.IsCall.Size = new System.Drawing.Size(88, 22);
            this.IsCall.TabIndex = 14;
            this.IsCall.Text = "IsCall";
            this.IsCall.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(710, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Delta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(682, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Option Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "S";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "K";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "R";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Sigma";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 18);
            this.label7.TabIndex = 22;
            this.label7.Text = "T";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Trials";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 18);
            this.label9.TabIndex = 24;
            this.label9.Text = "Steps";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(710, 392);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 18);
            this.label10.TabIndex = 25;
            this.label10.Text = "SE";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(710, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 18);
            this.label11.TabIndex = 26;
            this.label11.Text = "Gamma";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(710, 344);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 18);
            this.label12.TabIndex = 27;
            this.label12.Text = "Rho";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(710, 278);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 18);
            this.label13.TabIndex = 28;
            this.label13.Text = "Theta";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(710, 231);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 18);
            this.label14.TabIndex = 29;
            this.label14.Text = "Vega";
            // 
            // Ant
            // 
            this.Ant.AutoSize = true;
            this.Ant.Location = new System.Drawing.Point(303, 100);
            this.Ant.Name = "Ant";
            this.Ant.Size = new System.Drawing.Size(142, 22);
            this.Ant.TabIndex = 30;
            this.Ant.Text = "IsAntithetic";
            this.Ant.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1238, 25);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CV
            // 
            this.CV.AutoSize = true;
            this.CV.Location = new System.Drawing.Point(303, 148);
            this.CV.Name = "CV";
            this.CV.Size = new System.Drawing.Size(187, 22);
            this.CV.TabIndex = 32;
            this.CV.Text = "IsControlVariance";
            this.CV.UseVisualStyleBackColor = true;
            // 
            // textBox_time
            // 
            this.textBox_time.Location = new System.Drawing.Point(326, 292);
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.Size = new System.Drawing.Size(100, 28);
            this.textBox_time.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(310, 261);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 18);
            this.label15.TabIndex = 34;
            this.label15.Text = "Operating time";
            // 
            // MT
            // 
            this.MT.AutoSize = true;
            this.MT.Location = new System.Drawing.Point(303, 188);
            this.MT.Name = "MT";
            this.MT.Size = new System.Drawing.Size(160, 22);
            this.MT.TabIndex = 35;
            this.MT.Text = "Multithreading";
            this.MT.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(896, 68);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(320, 30);
            this.progressBar1.TabIndex = 37;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(884, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 18);
            this.label16.TabIndex = 38;
            // 
            // label_bar
            // 
            this.label_bar.Location = new System.Drawing.Point(896, 112);
            this.label_bar.Name = "label_bar";
            this.label_bar.Size = new System.Drawing.Size(80, 28);
            this.label_bar.TabIndex = 39;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(936, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 45);
            this.button2.TabIndex = 41;
            this.button2.Text = "Simulation!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(982, 123);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 18);
            this.label17.TabIndex = 43;
            this.label17.Text = "core number";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1238, 450);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label_bar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.MT);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox_time);
            this.Controls.Add(this.CV);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Ant);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IsCall);
            this.Controls.Add(this.textBox_Delta);
            this.Controls.Add(this.textBox_Gamma);
            this.Controls.Add(this.textBox_Vega);
            this.Controls.Add(this.textBox_Theta);
            this.Controls.Add(this.textBox_Rho);
            this.Controls.Add(this.textBox_Std);
            this.Controls.Add(this.textBox_Steps);
            this.Controls.Add(this.textBox_Trials);
            this.Controls.Add(this.textBox_T);
            this.Controls.Add(this.textBox_Sigma);
            this.Controls.Add(this.textBox_R);
            this.Controls.Add(this.textBox_K);
            this.Controls.Add(this.textBox_S);
            this.Controls.Add(this.textBox_OptionPrice);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_OptionPrice;
        private System.Windows.Forms.TextBox textBox_S;
        private System.Windows.Forms.TextBox textBox_K;
        private System.Windows.Forms.TextBox textBox_R;
        private System.Windows.Forms.TextBox textBox_Sigma;
        private System.Windows.Forms.TextBox textBox_T;
        private System.Windows.Forms.TextBox textBox_Trials;
        private System.Windows.Forms.TextBox textBox_Steps;
        private System.Windows.Forms.TextBox textBox_Std;
        private System.Windows.Forms.TextBox textBox_Rho;
        private System.Windows.Forms.TextBox textBox_Theta;
        private System.Windows.Forms.TextBox textBox_Vega;
        private System.Windows.Forms.TextBox textBox_Gamma;
        private System.Windows.Forms.TextBox textBox_Delta;
        private System.Windows.Forms.CheckBox IsCall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox Ant;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.CheckBox CV;
        private System.Windows.Forms.TextBox textBox_time;
        private System.Windows.Forms.Label label15;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.CheckBox MT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox label_bar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label17;
    }
}

