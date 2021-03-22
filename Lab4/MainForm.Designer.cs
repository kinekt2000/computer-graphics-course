
namespace Lab4
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.glControl = new OpenTK.GLControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.genDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.gen_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gen_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.gen_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.gen_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.gen_5 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Location = new System.Drawing.Point(0, 0);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(800, 450);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genDropDownButton});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // genDropDownButton
            // 
            this.genDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gen_5,
            this.gen_4,
            this.gen_3,
            this.gen_2,
            this.gen_1});
            this.genDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("genDropDownButton.Image")));
            this.genDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.genDropDownButton.Name = "genDropDownButton";
            this.genDropDownButton.Size = new System.Drawing.Size(106, 20);
            this.genDropDownButton.Text = "Generation: 1";
            this.genDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.genDropDownButton_DropDownItemClicked);
            // 
            // gen_1
            // 
            this.gen_1.Name = "gen_1";
            this.gen_1.Size = new System.Drawing.Size(180, 22);
            this.gen_1.Text = "1";
            // 
            // gen_2
            // 
            this.gen_2.Name = "gen_2";
            this.gen_2.Size = new System.Drawing.Size(180, 22);
            this.gen_2.Text = "2";
            // 
            // gen_3
            // 
            this.gen_3.Name = "gen_3";
            this.gen_3.Size = new System.Drawing.Size(180, 22);
            this.gen_3.Text = "3";
            // 
            // gen_4
            // 
            this.gen_4.Name = "gen_4";
            this.gen_4.Size = new System.Drawing.Size(180, 22);
            this.gen_4.Text = "4";
            // 
            // gen_5
            // 
            this.gen_5.Name = "gen_5";
            this.gen_5.Size = new System.Drawing.Size(180, 22);
            this.gen_5.Text = "5";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.glControl);
            this.Name = "MainForm";
            this.Text = "CG LR4 V50";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton genDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem gen_5;
        private System.Windows.Forms.ToolStripMenuItem gen_4;
        private System.Windows.Forms.ToolStripMenuItem gen_3;
        private System.Windows.Forms.ToolStripMenuItem gen_2;
        private System.Windows.Forms.ToolStripMenuItem gen_1;
    }
}

