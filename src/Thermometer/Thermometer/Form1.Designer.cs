namespace Thermometer
{
    partial class Thermometer
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
            this.guageThermometer = new AGaugeApp.AGauge();
            this.label1 = new System.Windows.Forms.Label();
            this.guageNoiseLevel = new AGaugeApp.AGauge();
            this.lblNoiseLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guageThermometer
            // 
            this.guageThermometer.BaseArcColor = System.Drawing.Color.Gray;
            this.guageThermometer.BaseArcRadius = 40;
            this.guageThermometer.BaseArcStart = 180;
            this.guageThermometer.BaseArcSweep = 330;
            this.guageThermometer.BaseArcWidth = 2;
            this.guageThermometer.Cap_Idx = ((byte)(1));
            this.guageThermometer.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.guageThermometer.CapPosition = new System.Drawing.Point(10, 10);
            this.guageThermometer.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.guageThermometer.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.guageThermometer.CapText = "";
            this.guageThermometer.Center = new System.Drawing.Point(70, 70);
            this.guageThermometer.Location = new System.Drawing.Point(12, 12);
            this.guageThermometer.MaxValue = 50F;
            this.guageThermometer.MinValue = 0F;
            this.guageThermometer.Name = "guageThermometer";
            this.guageThermometer.NeedleColor1 = AGaugeApp.AGauge.NeedleColorEnum.Gray;
            this.guageThermometer.NeedleColor2 = System.Drawing.Color.Black;
            this.guageThermometer.NeedleRadius = 45;
            this.guageThermometer.NeedleType = 0;
            this.guageThermometer.NeedleWidth = 3;
            this.guageThermometer.Range_Idx = ((byte)(1));
            this.guageThermometer.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guageThermometer.RangeEnabled = false;
            this.guageThermometer.RangeEndValue = 400F;
            this.guageThermometer.RangeInnerRadius = 10;
            this.guageThermometer.RangeOuterRadius = 40;
            this.guageThermometer.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.guageThermometer.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.guageThermometer.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.guageThermometer.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.guageThermometer.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.guageThermometer.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.guageThermometer.RangeStartValue = 300F;
            this.guageThermometer.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.guageThermometer.ScaleLinesInterInnerRadius = 42;
            this.guageThermometer.ScaleLinesInterOuterRadius = 50;
            this.guageThermometer.ScaleLinesInterWidth = 1;
            this.guageThermometer.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.guageThermometer.ScaleLinesMajorInnerRadius = 40;
            this.guageThermometer.ScaleLinesMajorOuterRadius = 50;
            this.guageThermometer.ScaleLinesMajorStepValue = 10F;
            this.guageThermometer.ScaleLinesMajorWidth = 2;
            this.guageThermometer.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.guageThermometer.ScaleLinesMinorInnerRadius = 43;
            this.guageThermometer.ScaleLinesMinorNumOf = 1;
            this.guageThermometer.ScaleLinesMinorOuterRadius = 50;
            this.guageThermometer.ScaleLinesMinorWidth = 1;
            this.guageThermometer.ScaleNumbersColor = System.Drawing.Color.Black;
            this.guageThermometer.ScaleNumbersFormat = null;
            this.guageThermometer.ScaleNumbersRadius = 62;
            this.guageThermometer.ScaleNumbersRotation = 0;
            this.guageThermometer.ScaleNumbersStartScaleLine = 1;
            this.guageThermometer.ScaleNumbersStepScaleLines = 2;
            this.guageThermometer.Size = new System.Drawing.Size(150, 142);
            this.guageThermometer.TabIndex = 19;
            this.guageThermometer.Text = "aGauge12";
            this.guageThermometer.Value = 0F;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(26, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Temperature";
            // 
            // guageNoiseLevel
            // 
            this.guageNoiseLevel.BaseArcColor = System.Drawing.Color.Gray;
            this.guageNoiseLevel.BaseArcRadius = 150;
            this.guageNoiseLevel.BaseArcStart = 215;
            this.guageNoiseLevel.BaseArcSweep = 110;
            this.guageNoiseLevel.BaseArcWidth = 2;
            this.guageNoiseLevel.Cap_Idx = ((byte)(1));
            this.guageNoiseLevel.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.guageNoiseLevel.CapPosition = new System.Drawing.Point(10, 10);
            this.guageNoiseLevel.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.guageNoiseLevel.CapsText = new string[] {
        "",
        "",
        "",
        "",
        ""};
            this.guageNoiseLevel.CapText = "";
            this.guageNoiseLevel.Center = new System.Drawing.Point(150, 180);
            this.guageNoiseLevel.Location = new System.Drawing.Point(224, 12);
            this.guageNoiseLevel.MaxValue = 300F;
            this.guageNoiseLevel.MinValue = -300F;
            this.guageNoiseLevel.Name = "guageNoiseLevel";
            this.guageNoiseLevel.NeedleColor1 = AGaugeApp.AGauge.NeedleColorEnum.Green;
            this.guageNoiseLevel.NeedleColor2 = System.Drawing.Color.DimGray;
            this.guageNoiseLevel.NeedleRadius = 150;
            this.guageNoiseLevel.NeedleType = 0;
            this.guageNoiseLevel.NeedleWidth = 2;
            this.guageNoiseLevel.Range_Idx = ((byte)(1));
            this.guageNoiseLevel.RangeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guageNoiseLevel.RangeEnabled = false;
            this.guageNoiseLevel.RangeEndValue = 400F;
            this.guageNoiseLevel.RangeInnerRadius = 10;
            this.guageNoiseLevel.RangeOuterRadius = 40;
            this.guageNoiseLevel.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))),
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.guageNoiseLevel.RangesEnabled = new bool[] {
        false,
        false,
        false,
        false,
        false};
            this.guageNoiseLevel.RangesEndValue = new float[] {
        300F,
        400F,
        0F,
        0F,
        0F};
            this.guageNoiseLevel.RangesInnerRadius = new int[] {
        70,
        10,
        70,
        70,
        70};
            this.guageNoiseLevel.RangesOuterRadius = new int[] {
        80,
        40,
        80,
        80,
        80};
            this.guageNoiseLevel.RangesStartValue = new float[] {
        -100F,
        300F,
        0F,
        0F,
        0F};
            this.guageNoiseLevel.RangeStartValue = 300F;
            this.guageNoiseLevel.ScaleLinesInterColor = System.Drawing.Color.Red;
            this.guageNoiseLevel.ScaleLinesInterInnerRadius = 145;
            this.guageNoiseLevel.ScaleLinesInterOuterRadius = 150;
            this.guageNoiseLevel.ScaleLinesInterWidth = 2;
            this.guageNoiseLevel.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.guageNoiseLevel.ScaleLinesMajorInnerRadius = 140;
            this.guageNoiseLevel.ScaleLinesMajorOuterRadius = 150;
            this.guageNoiseLevel.ScaleLinesMajorStepValue = 100F;
            this.guageNoiseLevel.ScaleLinesMajorWidth = 2;
            this.guageNoiseLevel.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.guageNoiseLevel.ScaleLinesMinorInnerRadius = 145;
            this.guageNoiseLevel.ScaleLinesMinorNumOf = 9;
            this.guageNoiseLevel.ScaleLinesMinorOuterRadius = 150;
            this.guageNoiseLevel.ScaleLinesMinorWidth = 1;
            this.guageNoiseLevel.ScaleNumbersColor = System.Drawing.Color.Black;
            this.guageNoiseLevel.ScaleNumbersFormat = null;
            this.guageNoiseLevel.ScaleNumbersRadius = 162;
            this.guageNoiseLevel.ScaleNumbersRotation = 90;
            this.guageNoiseLevel.ScaleNumbersStartScaleLine = 1;
            this.guageNoiseLevel.ScaleNumbersStepScaleLines = 2;
            this.guageNoiseLevel.Size = new System.Drawing.Size(297, 121);
            this.guageNoiseLevel.TabIndex = 22;
            this.guageNoiseLevel.Text = "aGauge4";
            this.guageNoiseLevel.Value = 0F;
            // 
            // lblNoiseLevel
            // 
            this.lblNoiseLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoiseLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoiseLevel.Location = new System.Drawing.Point(227, 148);
            this.lblNoiseLevel.Name = "lblNoiseLevel";
            this.lblNoiseLevel.Size = new System.Drawing.Size(294, 36);
            this.lblNoiseLevel.TabIndex = 24;
            this.lblNoiseLevel.Text = "Noise level";
            this.lblNoiseLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Thermometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 197);
            this.Controls.Add(this.lblNoiseLevel);
            this.Controls.Add(this.guageNoiseLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guageThermometer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Thermometer";
            this.Text = "Thermometer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AGaugeApp.AGauge guageThermometer;
        private System.Windows.Forms.Label label1;
        private AGaugeApp.AGauge guageNoiseLevel;
        private System.Windows.Forms.Label lblNoiseLevel;

    }
}

