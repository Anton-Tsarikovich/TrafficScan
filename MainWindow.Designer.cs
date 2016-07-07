    namespace iipyLab7
{
    partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.startButton = new System.Windows.Forms.Button();
            this.textLabel1 = new System.Windows.Forms.Label();
            this.textLabel2 = new System.Windows.Forms.Label();
            this.textLabel3 = new System.Windows.Forms.Label();
            this.startMeterage = new System.Windows.Forms.Label();
            this.finishMeterage = new System.Windows.Forms.Label();
            this.workTime = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.trafficDiagramm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.trafficCount = new System.Windows.Forms.Label();
            this.saveGraphic = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.totalTraffic = new System.Windows.Forms.Label();
            this.toTray = new System.Windows.Forms.Button();
            this.notifySniffer = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trafficDiagramm)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(15, 383);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(107, 35);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButtonOnClick);
            // 
            // textLabel1
            // 
            this.textLabel1.AutoSize = true;
            this.textLabel1.Location = new System.Drawing.Point(9, 9);
            this.textLabel1.Name = "textLabel1";
            this.textLabel1.Size = new System.Drawing.Size(103, 13);
            this.textLabel1.TabIndex = 1;
            this.textLabel1.Text = "Начало измерения";
            // 
            // textLabel2
            // 
            this.textLabel2.AutoSize = true;
            this.textLabel2.Location = new System.Drawing.Point(10, 31);
            this.textLabel2.Name = "textLabel2";
            this.textLabel2.Size = new System.Drawing.Size(97, 13);
            this.textLabel2.TabIndex = 2;
            this.textLabel2.Text = "Конец измерения";
            // 
            // textLabel3
            // 
            this.textLabel3.AutoSize = true;
            this.textLabel3.Location = new System.Drawing.Point(10, 53);
            this.textLabel3.Name = "textLabel3";
            this.textLabel3.Size = new System.Drawing.Size(99, 13);
            this.textLabel3.TabIndex = 3;
            this.textLabel3.Text = "Время измерения";
            // 
            // startMeterage
            // 
            this.startMeterage.AutoSize = true;
            this.startMeterage.Location = new System.Drawing.Point(190, 9);
            this.startMeterage.Name = "startMeterage";
            this.startMeterage.Size = new System.Drawing.Size(0, 13);
            this.startMeterage.TabIndex = 4;
            // 
            // finishMeterage
            // 
            this.finishMeterage.AutoSize = true;
            this.finishMeterage.Location = new System.Drawing.Point(190, 31);
            this.finishMeterage.Name = "finishMeterage";
            this.finishMeterage.Size = new System.Drawing.Size(0, 13);
            this.finishMeterage.TabIndex = 5;
            // 
            // workTime
            // 
            this.workTime.AutoSize = true;
            this.workTime.Location = new System.Drawing.Point(190, 53);
            this.workTime.Name = "workTime";
            this.workTime.Size = new System.Drawing.Size(0, 13);
            this.workTime.TabIndex = 6;
            // 
            // trafficDiagramm
            // 
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.AxisY.Maximum = 1000D;
            chartArea1.AxisY.ScaleView.SmallScrollMinSize = 20D;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.trafficDiagramm.ChartAreas.Add(chartArea1);
            this.trafficDiagramm.Location = new System.Drawing.Point(307, 31);
            this.trafficDiagramm.Name = "trafficDiagramm";
            this.trafficDiagramm.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.trafficDiagramm.Series.Add(series1);
            this.trafficDiagramm.Size = new System.Drawing.Size(491, 376);
            this.trafficDiagramm.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Текущий трафик";
            // 
            // trafficCount
            // 
            this.trafficCount.AutoSize = true;
            this.trafficCount.Location = new System.Drawing.Point(190, 74);
            this.trafficCount.Name = "trafficCount";
            this.trafficCount.Size = new System.Drawing.Size(0, 13);
            this.trafficCount.TabIndex = 9;
            // 
            // saveGraphic
            // 
            this.saveGraphic.Location = new System.Drawing.Point(15, 321);
            this.saveGraphic.Name = "saveGraphic";
            this.saveGraphic.Size = new System.Drawing.Size(107, 40);
            this.saveGraphic.TabIndex = 21;
            this.saveGraphic.Text = "Сохранить график";
            this.saveGraphic.UseVisualStyleBackColor = true;
            this.saveGraphic.Click += new System.EventHandler(this.saveGraphic_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(15, 261);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(107, 39);
            this.clearButton.TabIndex = 22;
            this.clearButton.Text = "Очистить график";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Общий трафик";
            // 
            // totalTraffic
            // 
            this.totalTraffic.AutoSize = true;
            this.totalTraffic.Location = new System.Drawing.Point(190, 98);
            this.totalTraffic.Name = "totalTraffic";
            this.totalTraffic.Size = new System.Drawing.Size(0, 13);
            this.totalTraffic.TabIndex = 24;
            // 
            // toTray
            // 
            this.toTray.Location = new System.Drawing.Point(16, 205);
            this.toTray.Name = "toTray";
            this.toTray.Size = new System.Drawing.Size(106, 39);
            this.toTray.TabIndex = 25;
            this.toTray.Text = "Свернуть в трей";
            this.toTray.UseVisualStyleBackColor = true;
            this.toTray.Click += new System.EventHandler(this.toTray_Click);
            // 
            // notifySniffer
            // 
            this.notifySniffer.Icon = ((System.Drawing.Icon)(resources.GetObject("notifySniffer.Icon")));
            this.notifySniffer.Text = "Sniffer";
            this.notifySniffer.Visible = true;
            this.notifySniffer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifySniffer_MouseDoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 444);
            this.Controls.Add(this.toTray);
            this.Controls.Add(this.totalTraffic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.saveGraphic);
            this.Controls.Add(this.trafficCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trafficDiagramm);
            this.Controls.Add(this.workTime);
            this.Controls.Add(this.finishMeterage);
            this.Controls.Add(this.startMeterage);
            this.Controls.Add(this.textLabel3);
            this.Controls.Add(this.textLabel2);
            this.Controls.Add(this.textLabel1);
            this.Controls.Add(this.startButton);
            this.Name = "MainWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trafficDiagramm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label textLabel1;
        private System.Windows.Forms.Label textLabel2;
        private System.Windows.Forms.Label textLabel3;
        private System.Windows.Forms.Label startMeterage;
        private System.Windows.Forms.Label finishMeterage;
        private System.Windows.Forms.Label workTime;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart trafficDiagramm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label trafficCount;
        private System.Windows.Forms.Button saveGraphic;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalTraffic;
        private System.Windows.Forms.Button toTray;
        private System.Windows.Forms.NotifyIcon notifySniffer;
    }
}

