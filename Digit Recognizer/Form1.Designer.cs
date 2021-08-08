namespace Digit_Recognizer
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ErrorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnStart = new System.Windows.Forms.Button();
            this.chrtTotalError = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.IdentifyMultiple = new System.Windows.Forms.Button();
            this.btnClearLarge = new System.Windows.Forms.Button();
            this.btnSmall = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.txtBrightness = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.largeDrawingPanel = new Digit_Recognizer.DrawingPanel();
            this.drawingPanel1 = new Digit_Recognizer.DrawingPanel();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTotalError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ErrorChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ErrorChart.Legends.Add(legend1);
            this.ErrorChart.Location = new System.Drawing.Point(12, 12);
            this.ErrorChart.Name = "ErrorChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Errors";
            this.ErrorChart.Series.Add(series1);
            this.ErrorChart.Size = new System.Drawing.Size(418, 267);
            this.ErrorChart.TabIndex = 0;
            this.ErrorChart.Text = "Error Chart";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 268);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(831, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Training";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chrtTotalError
            // 
            chartArea2.Name = "ChartArea1";
            this.chrtTotalError.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrtTotalError.Legends.Add(legend2);
            this.chrtTotalError.Location = new System.Drawing.Point(425, 12);
            this.chrtTotalError.Name = "chrtTotalError";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series2.Legend = "Legend1";
            series2.Name = "Errors";
            this.chrtTotalError.Series.Add(series2);
            this.chrtTotalError.Size = new System.Drawing.Size(418, 267);
            this.chrtTotalError.TabIndex = 2;
            this.chrtTotalError.Text = "Error Chart";
            this.chrtTotalError.Click += new System.EventHandler(this.chrtTotalError_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(863, 298);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(280, 23);
            this.btnIdentify.TabIndex = 4;
            this.btnIdentify.Text = "Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1149, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Digit:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(863, 327);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(280, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1189, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 140);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // IdentifyMultiple
            // 
            this.IdentifyMultiple.Location = new System.Drawing.Point(12, 621);
            this.IdentifyMultiple.Name = "IdentifyMultiple";
            this.IdentifyMultiple.Size = new System.Drawing.Size(840, 23);
            this.IdentifyMultiple.TabIndex = 8;
            this.IdentifyMultiple.Text = "Identify";
            this.IdentifyMultiple.UseVisualStyleBackColor = true;
            this.IdentifyMultiple.Click += new System.EventHandler(this.IdentifyMultiple_Click);
            // 
            // btnClearLarge
            // 
            this.btnClearLarge.Location = new System.Drawing.Point(12, 650);
            this.btnClearLarge.Name = "btnClearLarge";
            this.btnClearLarge.Size = new System.Drawing.Size(280, 23);
            this.btnClearLarge.TabIndex = 9;
            this.btnClearLarge.Text = "Clear";
            this.btnClearLarge.UseVisualStyleBackColor = true;
            this.btnClearLarge.Click += new System.EventHandler(this.btnClearLarge_Click);
            // 
            // btnSmall
            // 
            this.btnSmall.Location = new System.Drawing.Point(863, 368);
            this.btnSmall.Name = "btnSmall";
            this.btnSmall.Size = new System.Drawing.Size(75, 23);
            this.btnSmall.TabIndex = 10;
            this.btnSmall.Text = "Small";
            this.btnSmall.UseVisualStyleBackColor = true;
            this.btnSmall.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnMedium
            // 
            this.btnMedium.Location = new System.Drawing.Point(863, 397);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(75, 23);
            this.btnMedium.TabIndex = 11;
            this.btnMedium.Text = "Medium";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(868, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Number Classification";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.Location = new System.Drawing.Point(868, 482);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(0, 37);
            this.lblNumber.TabIndex = 12;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1356, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 140);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(1525, 35);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(140, 140);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(1689, 35);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(140, 140);
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(1189, 194);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(140, 140);
            this.pictureBox5.TabIndex = 16;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(1356, 194);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(140, 140);
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(1525, 194);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(140, 140);
            this.pictureBox7.TabIndex = 18;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(1689, 194);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(140, 140);
            this.pictureBox8.TabIndex = 19;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Location = new System.Drawing.Point(1356, 368);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(140, 140);
            this.pictureBox9.TabIndex = 20;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Location = new System.Drawing.Point(1525, 368);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(140, 140);
            this.pictureBox10.TabIndex = 21;
            this.pictureBox10.TabStop = false;
            // 
            // txtBrightness
            // 
            this.txtBrightness.Location = new System.Drawing.Point(1232, 587);
            this.txtBrightness.Name = "txtBrightness";
            this.txtBrightness.Size = new System.Drawing.Size(100, 20);
            this.txtBrightness.TabIndex = 22;
            this.txtBrightness.Text = "10000";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // largeDrawingPanel
            // 
            this.largeDrawingPanel.BackColor = System.Drawing.Color.White;
            this.largeDrawingPanel.ImageOnPanel = ((System.Drawing.Bitmap)(resources.GetObject("largeDrawingPanel.ImageOnPanel")));
            this.largeDrawingPanel.Location = new System.Drawing.Point(12, 335);
            this.largeDrawingPanel.Name = "largeDrawingPanel";
            this.largeDrawingPanel.PointSize = 10;
            this.largeDrawingPanel.Size = new System.Drawing.Size(840, 280);
            this.largeDrawingPanel.TabIndex = 4;
            // 
            // drawingPanel1
            // 
            this.drawingPanel1.BackColor = System.Drawing.Color.White;
            this.drawingPanel1.ImageOnPanel = ((System.Drawing.Bitmap)(resources.GetObject("drawingPanel1.ImageOnPanel")));
            this.drawingPanel1.Location = new System.Drawing.Point(863, 12);
            this.drawingPanel1.Name = "drawingPanel1";
            this.drawingPanel1.PointSize = 10;
            this.drawingPanel1.Size = new System.Drawing.Size(280, 280);
            this.drawingPanel1.TabIndex = 3;
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Location = new System.Drawing.Point(679, 300);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(100, 20);
            this.txtBatchSize.TabIndex = 24;
            this.txtBatchSize.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1338, 590);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Brightness";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(785, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Batch Size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 917);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBatchSize);
            this.Controls.Add(this.txtBrightness);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnSmall);
            this.Controls.Add(this.btnClearLarge);
            this.Controls.Add(this.IdentifyMultiple);
            this.Controls.Add(this.largeDrawingPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIdentify);
            this.Controls.Add(this.drawingPanel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.ErrorChart);
            this.Controls.Add(this.chrtTotalError);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTotalError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ErrorChart;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtTotalError;
        private DrawingPanel drawingPanel1;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DrawingPanel largeDrawingPanel;
        private System.Windows.Forms.Button IdentifyMultiple;
        private System.Windows.Forms.Button btnClearLarge;
        private System.Windows.Forms.Button btnSmall;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox txtBrightness;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtBatchSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

