
namespace Primitives
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
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.glControl = new OpenTK.GLControl();
            this.SettingsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.PrimitiveLabel = new System.Windows.Forms.Label();
            this.primitiveType = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.MainLayout.SuspendLayout();
            this.SettingsLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.MainLayout.Controls.Add(this.glControl, 0, 0);
            this.MainLayout.Controls.Add(this.SettingsLayout, 1, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 1;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.Size = new System.Drawing.Size(759, 511);
            this.MainLayout.TabIndex = 0;
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Location = new System.Drawing.Point(3, 3);
            this.glControl.MinimumSize = new System.Drawing.Size(500, 500);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(503, 505);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // SettingsLayout
            // 
            this.SettingsLayout.ColumnCount = 2;
            this.SettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.SettingsLayout.Controls.Add(this.PrimitiveLabel, 0, 0);
            this.SettingsLayout.Controls.Add(this.primitiveType, 1, 0);
            this.SettingsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsLayout.Location = new System.Drawing.Point(512, 3);
            this.SettingsLayout.Name = "SettingsLayout";
            this.SettingsLayout.RowCount = 3;
            this.SettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SettingsLayout.Size = new System.Drawing.Size(244, 505);
            this.SettingsLayout.TabIndex = 1;
            // 
            // PrimitiveLabel
            // 
            this.PrimitiveLabel.AutoSize = true;
            this.PrimitiveLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.PrimitiveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrimitiveLabel.Location = new System.Drawing.Point(38, 0);
            this.PrimitiveLabel.Name = "PrimitiveLabel";
            this.PrimitiveLabel.Size = new System.Drawing.Size(61, 27);
            this.PrimitiveLabel.TabIndex = 0;
            this.PrimitiveLabel.Text = "Primitive";
            this.PrimitiveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // primitiveType
            // 
            this.primitiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.primitiveType.FormattingEnabled = true;
            this.primitiveType.Location = new System.Drawing.Point(105, 3);
            this.primitiveType.Name = "primitiveType";
            this.primitiveType.Size = new System.Drawing.Size(136, 21);
            this.primitiveType.TabIndex = 1;
            this.primitiveType.SelectedValueChanged += new System.EventHandler(this.primitiveType_SelectedValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 511);
            this.Controls.Add(this.MainLayout);
            this.MinimumSize = new System.Drawing.Size(775, 550);
            this.Name = "MainForm";
            this.Text = "CG Greehsheen LR1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainLayout.ResumeLayout(false);
            this.SettingsLayout.ResumeLayout(false);
            this.SettingsLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.TableLayoutPanel SettingsLayout;
        private System.Windows.Forms.Label PrimitiveLabel;
        private System.Windows.Forms.ComboBox primitiveType;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

