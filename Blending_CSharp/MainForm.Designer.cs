
namespace Blending
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
            this.ParametersLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SettingsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.PrimitiveLabel = new System.Windows.Forms.Label();
            this.primitiveType = new System.Windows.Forms.ComboBox();
            this.ExtraSettingsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ScissorBox = new System.Windows.Forms.GroupBox();
            this.ScissorLayout = new System.Windows.Forms.TableLayoutPanel();
            this.scissorX = new System.Windows.Forms.TrackBar();
            this.scissorY = new System.Windows.Forms.TrackBar();
            this.scissorW = new System.Windows.Forms.TrackBar();
            this.scissorH = new System.Windows.Forms.TrackBar();
            this.scissorXLabel = new System.Windows.Forms.Label();
            this.scissorYLabel = new System.Windows.Forms.Label();
            this.scissorWLabel = new System.Windows.Forms.Label();
            this.scissorHLabel = new System.Windows.Forms.Label();
            this.AlphaBox = new System.Windows.Forms.GroupBox();
            this.AlphaLayout = new System.Windows.Forms.TableLayoutPanel();
            this.alphaPropertyLayout = new System.Windows.Forms.TableLayoutPanel();
            this.alphaPropertyLabel = new System.Windows.Forms.Label();
            this.alphaProperty = new System.Windows.Forms.ComboBox();
            this.alphaValueLayout = new System.Windows.Forms.TableLayoutPanel();
            this.alphaLabel = new System.Windows.Forms.Label();
            this.alpha = new System.Windows.Forms.TrackBar();
            this.BlendBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.sfactorLabel = new System.Windows.Forms.Label();
            this.dfactorLabel = new System.Windows.Forms.Label();
            this.sfactor = new System.Windows.Forms.ComboBox();
            this.dfactor = new System.Windows.Forms.ComboBox();
            this.glControl = new OpenTK.GLControl();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.MainLayout.SuspendLayout();
            this.ParametersLayout.SuspendLayout();
            this.SettingsLayout.SuspendLayout();
            this.ExtraSettingsLayout.SuspendLayout();
            this.ScissorBox.SuspendLayout();
            this.ScissorLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scissorX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scissorY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scissorW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scissorH)).BeginInit();
            this.AlphaBox.SuspendLayout();
            this.AlphaLayout.SuspendLayout();
            this.alphaPropertyLayout.SuspendLayout();
            this.alphaValueLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alpha)).BeginInit();
            this.BlendBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.MainLayout.Controls.Add(this.ParametersLayout, 1, 0);
            this.MainLayout.Controls.Add(this.glControl, 0, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 1;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.Size = new System.Drawing.Size(761, 511);
            this.MainLayout.TabIndex = 0;
            // 
            // ParametersLayout
            // 
            this.ParametersLayout.ColumnCount = 1;
            this.ParametersLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ParametersLayout.Controls.Add(this.SettingsLayout, 0, 0);
            this.ParametersLayout.Controls.Add(this.ExtraSettingsLayout, 0, 1);
            this.ParametersLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParametersLayout.Location = new System.Drawing.Point(514, 3);
            this.ParametersLayout.Name = "ParametersLayout";
            this.ParametersLayout.RowCount = 2;
            this.ParametersLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ParametersLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.ParametersLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ParametersLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ParametersLayout.Size = new System.Drawing.Size(244, 505);
            this.ParametersLayout.TabIndex = 1;
            // 
            // SettingsLayout
            // 
            this.SettingsLayout.ColumnCount = 2;
            this.SettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.SettingsLayout.Controls.Add(this.PrimitiveLabel, 0, 0);
            this.SettingsLayout.Controls.Add(this.primitiveType, 1, 0);
            this.SettingsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsLayout.Location = new System.Drawing.Point(0, 0);
            this.SettingsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsLayout.Name = "SettingsLayout";
            this.SettingsLayout.RowCount = 3;
            this.SettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.SettingsLayout.Size = new System.Drawing.Size(244, 165);
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
            // ExtraSettingsLayout
            // 
            this.ExtraSettingsLayout.ColumnCount = 1;
            this.ExtraSettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExtraSettingsLayout.Controls.Add(this.ScissorBox, 0, 0);
            this.ExtraSettingsLayout.Controls.Add(this.AlphaBox, 0, 1);
            this.ExtraSettingsLayout.Controls.Add(this.BlendBox, 0, 2);
            this.ExtraSettingsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtraSettingsLayout.Location = new System.Drawing.Point(0, 165);
            this.ExtraSettingsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.ExtraSettingsLayout.Name = "ExtraSettingsLayout";
            this.ExtraSettingsLayout.RowCount = 3;
            this.ParametersLayout.SetRowSpan(this.ExtraSettingsLayout, 3);
            this.ExtraSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.ExtraSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.ExtraSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.ExtraSettingsLayout.Size = new System.Drawing.Size(244, 340);
            this.ExtraSettingsLayout.TabIndex = 2;
            // 
            // ScissorBox
            // 
            this.ScissorBox.Controls.Add(this.ScissorLayout);
            this.ScissorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScissorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScissorBox.Location = new System.Drawing.Point(0, 0);
            this.ScissorBox.Margin = new System.Windows.Forms.Padding(0);
            this.ScissorBox.Name = "ScissorBox";
            this.ScissorBox.Size = new System.Drawing.Size(244, 136);
            this.ScissorBox.TabIndex = 0;
            this.ScissorBox.TabStop = false;
            this.ScissorBox.Text = "Scissor";
            // 
            // ScissorLayout
            // 
            this.ScissorLayout.ColumnCount = 2;
            this.ScissorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ScissorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ScissorLayout.Controls.Add(this.scissorX, 0, 1);
            this.ScissorLayout.Controls.Add(this.scissorY, 1, 1);
            this.ScissorLayout.Controls.Add(this.scissorW, 0, 3);
            this.ScissorLayout.Controls.Add(this.scissorH, 1, 3);
            this.ScissorLayout.Controls.Add(this.scissorXLabel, 0, 0);
            this.ScissorLayout.Controls.Add(this.scissorYLabel, 1, 0);
            this.ScissorLayout.Controls.Add(this.scissorWLabel, 0, 2);
            this.ScissorLayout.Controls.Add(this.scissorHLabel, 1, 2);
            this.ScissorLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScissorLayout.Location = new System.Drawing.Point(3, 19);
            this.ScissorLayout.Margin = new System.Windows.Forms.Padding(0);
            this.ScissorLayout.Name = "ScissorLayout";
            this.ScissorLayout.RowCount = 4;
            this.ScissorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ScissorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.ScissorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ScissorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.ScissorLayout.Size = new System.Drawing.Size(238, 114);
            this.ScissorLayout.TabIndex = 0;
            // 
            // scissorX
            // 
            this.scissorX.Dock = System.Windows.Forms.DockStyle.Top;
            this.scissorX.LargeChange = 1;
            this.scissorX.Location = new System.Drawing.Point(3, 25);
            this.scissorX.Name = "scissorX";
            this.scissorX.Size = new System.Drawing.Size(113, 28);
            this.scissorX.TabIndex = 0;
            // 
            // scissorY
            // 
            this.scissorY.Dock = System.Windows.Forms.DockStyle.Top;
            this.scissorY.LargeChange = 1;
            this.scissorY.Location = new System.Drawing.Point(122, 25);
            this.scissorY.Name = "scissorY";
            this.scissorY.Size = new System.Drawing.Size(113, 28);
            this.scissorY.TabIndex = 1;
            // 
            // scissorW
            // 
            this.scissorW.Dock = System.Windows.Forms.DockStyle.Top;
            this.scissorW.LargeChange = 1;
            this.scissorW.Location = new System.Drawing.Point(3, 81);
            this.scissorW.Name = "scissorW";
            this.scissorW.Size = new System.Drawing.Size(113, 30);
            this.scissorW.TabIndex = 2;
            this.scissorW.Value = 10;
            // 
            // scissorH
            // 
            this.scissorH.Dock = System.Windows.Forms.DockStyle.Top;
            this.scissorH.LargeChange = 1;
            this.scissorH.Location = new System.Drawing.Point(122, 81);
            this.scissorH.Name = "scissorH";
            this.scissorH.Size = new System.Drawing.Size(113, 30);
            this.scissorH.TabIndex = 3;
            this.scissorH.Value = 10;
            // 
            // scissorXLabel
            // 
            this.scissorXLabel.AutoSize = true;
            this.scissorXLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scissorXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scissorXLabel.Location = new System.Drawing.Point(3, 9);
            this.scissorXLabel.Name = "scissorXLabel";
            this.scissorXLabel.Size = new System.Drawing.Size(113, 13);
            this.scissorXLabel.TabIndex = 4;
            this.scissorXLabel.Text = "X";
            // 
            // scissorYLabel
            // 
            this.scissorYLabel.AutoSize = true;
            this.scissorYLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scissorYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scissorYLabel.Location = new System.Drawing.Point(122, 9);
            this.scissorYLabel.Name = "scissorYLabel";
            this.scissorYLabel.Size = new System.Drawing.Size(113, 13);
            this.scissorYLabel.TabIndex = 5;
            this.scissorYLabel.Text = "Y";
            // 
            // scissorWLabel
            // 
            this.scissorWLabel.AutoSize = true;
            this.scissorWLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scissorWLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scissorWLabel.Location = new System.Drawing.Point(3, 65);
            this.scissorWLabel.Name = "scissorWLabel";
            this.scissorWLabel.Size = new System.Drawing.Size(113, 13);
            this.scissorWLabel.TabIndex = 6;
            this.scissorWLabel.Text = "W";
            // 
            // scissorHLabel
            // 
            this.scissorHLabel.AutoSize = true;
            this.scissorHLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scissorHLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scissorHLabel.Location = new System.Drawing.Point(122, 65);
            this.scissorHLabel.Name = "scissorHLabel";
            this.scissorHLabel.Size = new System.Drawing.Size(113, 13);
            this.scissorHLabel.TabIndex = 7;
            this.scissorHLabel.Text = "H";
            // 
            // AlphaBox
            // 
            this.AlphaBox.Controls.Add(this.AlphaLayout);
            this.AlphaBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlphaBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AlphaBox.Location = new System.Drawing.Point(0, 136);
            this.AlphaBox.Margin = new System.Windows.Forms.Padding(0);
            this.AlphaBox.Name = "AlphaBox";
            this.AlphaBox.Size = new System.Drawing.Size(244, 102);
            this.AlphaBox.TabIndex = 1;
            this.AlphaBox.TabStop = false;
            this.AlphaBox.Text = "Alpha";
            // 
            // AlphaLayout
            // 
            this.AlphaLayout.ColumnCount = 1;
            this.AlphaLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AlphaLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AlphaLayout.Controls.Add(this.alphaPropertyLayout, 0, 0);
            this.AlphaLayout.Controls.Add(this.alphaValueLayout, 0, 1);
            this.AlphaLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlphaLayout.Location = new System.Drawing.Point(3, 19);
            this.AlphaLayout.Margin = new System.Windows.Forms.Padding(0);
            this.AlphaLayout.Name = "AlphaLayout";
            this.AlphaLayout.RowCount = 2;
            this.AlphaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AlphaLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AlphaLayout.Size = new System.Drawing.Size(238, 80);
            this.AlphaLayout.TabIndex = 0;
            // 
            // alphaPropertyLayout
            // 
            this.alphaPropertyLayout.ColumnCount = 2;
            this.alphaPropertyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.alphaPropertyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.alphaPropertyLayout.Controls.Add(this.alphaPropertyLabel, 0, 0);
            this.alphaPropertyLayout.Controls.Add(this.alphaProperty, 1, 0);
            this.alphaPropertyLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alphaPropertyLayout.Location = new System.Drawing.Point(0, 0);
            this.alphaPropertyLayout.Margin = new System.Windows.Forms.Padding(0);
            this.alphaPropertyLayout.Name = "alphaPropertyLayout";
            this.alphaPropertyLayout.RowCount = 1;
            this.alphaPropertyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.alphaPropertyLayout.Size = new System.Drawing.Size(238, 40);
            this.alphaPropertyLayout.TabIndex = 0;
            // 
            // alphaPropertyLabel
            // 
            this.alphaPropertyLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.alphaPropertyLabel.AutoSize = true;
            this.alphaPropertyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.alphaPropertyLabel.Location = new System.Drawing.Point(3, 13);
            this.alphaPropertyLabel.Name = "alphaPropertyLabel";
            this.alphaPropertyLabel.Size = new System.Drawing.Size(45, 13);
            this.alphaPropertyLabel.TabIndex = 0;
            this.alphaPropertyLabel.Text = "property";
            // 
            // alphaProperty
            // 
            this.alphaProperty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.alphaProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alphaProperty.FormattingEnabled = true;
            this.alphaProperty.Location = new System.Drawing.Point(54, 9);
            this.alphaProperty.Name = "alphaProperty";
            this.alphaProperty.Size = new System.Drawing.Size(181, 25);
            this.alphaProperty.TabIndex = 1;
            // 
            // alphaValueLayout
            // 
            this.alphaValueLayout.ColumnCount = 2;
            this.alphaValueLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.alphaValueLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.alphaValueLayout.Controls.Add(this.alphaLabel, 0, 0);
            this.alphaValueLayout.Controls.Add(this.alpha, 1, 0);
            this.alphaValueLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alphaValueLayout.Location = new System.Drawing.Point(0, 40);
            this.alphaValueLayout.Margin = new System.Windows.Forms.Padding(0);
            this.alphaValueLayout.Name = "alphaValueLayout";
            this.alphaValueLayout.RowCount = 1;
            this.alphaValueLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.alphaValueLayout.Size = new System.Drawing.Size(238, 40);
            this.alphaValueLayout.TabIndex = 1;
            // 
            // alphaLabel
            // 
            this.alphaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.alphaLabel.Location = new System.Drawing.Point(3, 0);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(33, 13);
            this.alphaLabel.TabIndex = 0;
            this.alphaLabel.Text = "alpha";
            // 
            // alpha
            // 
            this.alpha.Dock = System.Windows.Forms.DockStyle.Top;
            this.alpha.LargeChange = 1;
            this.alpha.Location = new System.Drawing.Point(42, 3);
            this.alpha.Maximum = 100;
            this.alpha.MaximumSize = new System.Drawing.Size(300, 20);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(193, 20);
            this.alpha.TabIndex = 1;
            this.alpha.TickFrequency = 10;
            // 
            // BlendBox
            // 
            this.BlendBox.Controls.Add(this.tableLayoutPanel3);
            this.BlendBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlendBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BlendBox.Location = new System.Drawing.Point(0, 238);
            this.BlendBox.Margin = new System.Windows.Forms.Padding(0);
            this.BlendBox.Name = "BlendBox";
            this.BlendBox.Size = new System.Drawing.Size(244, 102);
            this.BlendBox.TabIndex = 2;
            this.BlendBox.TabStop = false;
            this.BlendBox.Text = "Blend";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.sfactorLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dfactorLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.sfactor, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dfactor, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(238, 80);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // sfactorLabel
            // 
            this.sfactorLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sfactorLabel.AutoSize = true;
            this.sfactorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sfactorLabel.Location = new System.Drawing.Point(4, 13);
            this.sfactorLabel.Name = "sfactorLabel";
            this.sfactorLabel.Size = new System.Drawing.Size(39, 13);
            this.sfactorLabel.TabIndex = 0;
            this.sfactorLabel.Text = "sfactor";
            // 
            // dfactorLabel
            // 
            this.dfactorLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dfactorLabel.AutoSize = true;
            this.dfactorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dfactorLabel.Location = new System.Drawing.Point(3, 53);
            this.dfactorLabel.Name = "dfactorLabel";
            this.dfactorLabel.Size = new System.Drawing.Size(40, 13);
            this.dfactorLabel.TabIndex = 1;
            this.dfactorLabel.Text = "dfactor";
            // 
            // sfactor
            // 
            this.sfactor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sfactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sfactor.FormattingEnabled = true;
            this.sfactor.Location = new System.Drawing.Point(49, 9);
            this.sfactor.Name = "sfactor";
            this.sfactor.Size = new System.Drawing.Size(186, 25);
            this.sfactor.TabIndex = 2;
            // 
            // dfactor
            // 
            this.dfactor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dfactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dfactor.FormattingEnabled = true;
            this.dfactor.Location = new System.Drawing.Point(49, 49);
            this.dfactor.Name = "dfactor";
            this.dfactor.Size = new System.Drawing.Size(186, 25);
            this.dfactor.TabIndex = 3;
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl.Location = new System.Drawing.Point(3, 3);
            this.glControl.MinimumSize = new System.Drawing.Size(500, 500);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(505, 505);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseDown);
            this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 511);
            this.Controls.Add(this.MainLayout);
            this.MinimumSize = new System.Drawing.Size(775, 550);
            this.Name = "MainForm";
            this.Text = "CG Greehsheen LR2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainLayout.ResumeLayout(false);
            this.ParametersLayout.ResumeLayout(false);
            this.SettingsLayout.ResumeLayout(false);
            this.SettingsLayout.PerformLayout();
            this.ExtraSettingsLayout.ResumeLayout(false);
            this.ScissorBox.ResumeLayout(false);
            this.ScissorLayout.ResumeLayout(false);
            this.ScissorLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scissorX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scissorY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scissorW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scissorH)).EndInit();
            this.AlphaBox.ResumeLayout(false);
            this.AlphaLayout.ResumeLayout(false);
            this.alphaPropertyLayout.ResumeLayout(false);
            this.alphaPropertyLayout.PerformLayout();
            this.alphaValueLayout.ResumeLayout(false);
            this.alphaValueLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alpha)).EndInit();
            this.BlendBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.TableLayoutPanel SettingsLayout;
        private System.Windows.Forms.Label PrimitiveLabel;
        private System.Windows.Forms.ComboBox primitiveType;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TableLayoutPanel ParametersLayout;
        private System.Windows.Forms.TableLayoutPanel ExtraSettingsLayout;
        private System.Windows.Forms.GroupBox ScissorBox;
        private System.Windows.Forms.GroupBox AlphaBox;
        private System.Windows.Forms.GroupBox BlendBox;
        private System.Windows.Forms.TableLayoutPanel ScissorLayout;
        private System.Windows.Forms.TrackBar scissorX;
        private System.Windows.Forms.TrackBar scissorY;
        private System.Windows.Forms.TrackBar scissorW;
        private System.Windows.Forms.TrackBar scissorH;
        private System.Windows.Forms.Label scissorXLabel;
        private System.Windows.Forms.Label scissorYLabel;
        private System.Windows.Forms.Label scissorWLabel;
        private System.Windows.Forms.Label scissorHLabel;
        private System.Windows.Forms.TableLayoutPanel AlphaLayout;
        private System.Windows.Forms.TableLayoutPanel alphaPropertyLayout;
        private System.Windows.Forms.TableLayoutPanel alphaValueLayout;
        private System.Windows.Forms.Label alphaPropertyLabel;
        private System.Windows.Forms.Label alphaLabel;
        private System.Windows.Forms.ComboBox alphaProperty;
        private System.Windows.Forms.TrackBar alpha;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label sfactorLabel;
        private System.Windows.Forms.Label dfactorLabel;
        private System.Windows.Forms.ComboBox sfactor;
        private System.Windows.Forms.ComboBox dfactor;
    }
}

