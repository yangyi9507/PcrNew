
namespace PcrNew.Pages
{
    partial class TemperatureGraphfrm
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
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.SuspendLayout();
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(1, 2);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(878, 356);
            this.formsPlot1.TabIndex = 0;
            // 
            // TemperatureGraphfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(959, 495);
            this.Controls.Add(this.formsPlot1);
            this.Name = "TemperatureGraphfrm";
            this.Text = "温度曲线";
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
    }
}