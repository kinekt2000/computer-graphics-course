
namespace BSpline
{
    partial class MainForm
    {
        // Обязательная переменная конструктора.
        private System.ComponentModel.IContainer components = null;

        // Освободить все используемые ресурсы.
        // disposing истинно, если управляемый ресурс должен быть удален; иначе ложно
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        // Требуемый метод для поддержки конструктора — не изменяйте 
        // содержимое этого метода с помощью редактора кода.
        private void InitializeComponent()
        {
            this.glControl = new OpenTK.GLControl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mousePositionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.orderWarningLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Location = new System.Drawing.Point(0, 0);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(800, 428);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseClick);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // statusStrip
            // 
            this.statusStrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.mousePositionLabel,
            this.orderWarningLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(32, 17);
            this.statusLabel.Text = "label";
            // 
            // mousePositionLabel
            // 
            this.mousePositionLabel.Name = "mousePositionLabel";
            this.mousePositionLabel.Size = new System.Drawing.Size(625, 17);
            this.mousePositionLabel.Spring = true;
            this.mousePositionLabel.Text = "(0; 0)";
            this.mousePositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // orderWarningLabel
            // 
            this.orderWarningLabel.Image = global::BSpline.Properties.Resources.warning;
            this.orderWarningLabel.Name = "orderWarningLabel";
            this.orderWarningLabel.Size = new System.Drawing.Size(97, 17);
            this.orderWarningLabel.Text = "order warning";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.statusStrip);
            this.Name = "MainForm";
            this.Text = "CG LR3 V28";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel mousePositionLabel;
        private System.Windows.Forms.ToolStripStatusLabel orderWarningLabel;
    }
}

