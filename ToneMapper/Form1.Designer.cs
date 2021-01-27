namespace ToneMapper {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tscLayer = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlRegion = new System.Windows.Forms.Panel();
            this.hScroll = new System.Windows.Forms.HScrollBar();
            this.vScroll = new System.Windows.Forms.VScrollBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picRegion = new System.Windows.Forms.PictureBox();
            this.tsbWrite = new System.Windows.Forms.ToolStripButton();
            this.tsbSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbEnableVelo = new System.Windows.Forms.ToolStripButton();
            this.tsbToneZoom = new System.Windows.Forms.ToolStripButton();
            this.tsbToneZoomout = new System.Windows.Forms.ToolStripButton();
            this.tsbVeloZoom = new System.Windows.Forms.ToolStripButton();
            this.tsbVeloZoomout = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.pnlRegion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscLayer,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.tsbWrite,
            this.tsbSelect,
            this.toolStripSeparator3,
            this.tsbEnableVelo,
            this.toolStripSeparator4,
            this.tsbToneZoom,
            this.tsbToneZoomout,
            this.tsbVeloZoom,
            this.tsbVeloZoomout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(365, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tscLayer
            // 
            this.tscLayer.AutoSize = false;
            this.tscLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscLayer.Items.AddRange(new object[] {
            "レイヤー1",
            "レイヤー2",
            "レイヤー3",
            "レイヤー4",
            "レイヤー5",
            "レイヤー6",
            "レイヤー7",
            "レイヤー8"});
            this.tscLayer.Name = "tscLayer";
            this.tscLayer.Size = new System.Drawing.Size(75, 23);
            this.tscLayer.SelectedIndexChanged += new System.EventHandler(this.tscLayer_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // pnlRegion
            // 
            this.pnlRegion.BackColor = System.Drawing.Color.Silver;
            this.pnlRegion.Controls.Add(this.hScroll);
            this.pnlRegion.Controls.Add(this.vScroll);
            this.pnlRegion.Controls.Add(this.picRegion);
            this.pnlRegion.Location = new System.Drawing.Point(12, 34);
            this.pnlRegion.Name = "pnlRegion";
            this.pnlRegion.Size = new System.Drawing.Size(313, 212);
            this.pnlRegion.TabIndex = 1;
            // 
            // hScroll
            // 
            this.hScroll.Location = new System.Drawing.Point(3, 195);
            this.hScroll.Maximum = 127;
            this.hScroll.Name = "hScroll";
            this.hScroll.Size = new System.Drawing.Size(290, 17);
            this.hScroll.TabIndex = 2;
            // 
            // vScroll
            // 
            this.vScroll.Location = new System.Drawing.Point(296, 4);
            this.vScroll.Name = "vScroll";
            this.vScroll.Size = new System.Drawing.Size(17, 188);
            this.vScroll.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picRegion
            // 
            this.picRegion.BackColor = System.Drawing.Color.White;
            this.picRegion.Location = new System.Drawing.Point(3, 3);
            this.picRegion.Name = "picRegion";
            this.picRegion.Size = new System.Drawing.Size(290, 189);
            this.picRegion.TabIndex = 0;
            this.picRegion.TabStop = false;
            this.picRegion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picRegion_MouseDown);
            this.picRegion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picRegion_MouseMove);
            this.picRegion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picRegion_MouseUp);
            // 
            // tsbWrite
            // 
            this.tsbWrite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWrite.Image = global::ToneMapper.Properties.Resources.write;
            this.tsbWrite.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbWrite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWrite.Name = "tsbWrite";
            this.tsbWrite.Size = new System.Drawing.Size(28, 28);
            this.tsbWrite.Text = "toolStripButton2";
            this.tsbWrite.Click += new System.EventHandler(this.tsbWrite_Click);
            // 
            // tsbSelect
            // 
            this.tsbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelect.Image = global::ToneMapper.Properties.Resources.select_disable;
            this.tsbSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelect.Name = "tsbSelect";
            this.tsbSelect.Size = new System.Drawing.Size(29, 28);
            this.tsbSelect.Text = "toolStripButton1";
            this.tsbSelect.Click += new System.EventHandler(this.tsbSelect_Click);
            // 
            // tsbEnableVelo
            // 
            this.tsbEnableVelo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEnableVelo.Image = global::ToneMapper.Properties.Resources.input_velo;
            this.tsbEnableVelo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEnableVelo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEnableVelo.Name = "tsbEnableVelo";
            this.tsbEnableVelo.Size = new System.Drawing.Size(28, 28);
            this.tsbEnableVelo.Text = "強弱入力(ON)";
            this.tsbEnableVelo.Click += new System.EventHandler(this.tsbEnableVelo_Click);
            // 
            // tsbToneZoom
            // 
            this.tsbToneZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbToneZoom.Image = global::ToneMapper.Properties.Resources.tone_zoom;
            this.tsbToneZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbToneZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToneZoom.Name = "tsbToneZoom";
            this.tsbToneZoom.Size = new System.Drawing.Size(28, 28);
            this.tsbToneZoom.ToolTipText = "音程方向拡大";
            this.tsbToneZoom.Click += new System.EventHandler(this.tsbToneZoom_Click);
            // 
            // tsbToneZoomout
            // 
            this.tsbToneZoomout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbToneZoomout.Image = global::ToneMapper.Properties.Resources.tone_zoomout;
            this.tsbToneZoomout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbToneZoomout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToneZoomout.Name = "tsbToneZoomout";
            this.tsbToneZoomout.Size = new System.Drawing.Size(28, 28);
            this.tsbToneZoomout.ToolTipText = "音程方向縮小";
            this.tsbToneZoomout.Click += new System.EventHandler(this.tsbToneZoomout_Click);
            // 
            // tsbVeloZoom
            // 
            this.tsbVeloZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbVeloZoom.Image = global::ToneMapper.Properties.Resources.velo_zoom;
            this.tsbVeloZoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbVeloZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVeloZoom.Name = "tsbVeloZoom";
            this.tsbVeloZoom.Size = new System.Drawing.Size(28, 28);
            this.tsbVeloZoom.ToolTipText = "強弱方向拡大";
            this.tsbVeloZoom.Click += new System.EventHandler(this.tsbVeloZoom_Click);
            // 
            // tsbVeloZoomout
            // 
            this.tsbVeloZoomout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbVeloZoomout.Image = global::ToneMapper.Properties.Resources.velo_zoomout;
            this.tsbVeloZoomout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbVeloZoomout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVeloZoomout.Name = "tsbVeloZoomout";
            this.tsbVeloZoomout.Size = new System.Drawing.Size(28, 28);
            this.tsbVeloZoomout.ToolTipText = "強弱方向縮小";
            this.tsbVeloZoomout.Click += new System.EventHandler(this.tsbVeloZoomout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 258);
            this.Controls.Add(this.pnlRegion);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlRegion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRegion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tscLayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbToneZoom;
        private System.Windows.Forms.ToolStripButton tsbToneZoomout;
        private System.Windows.Forms.ToolStripButton tsbVeloZoom;
        private System.Windows.Forms.ToolStripButton tsbVeloZoomout;
        private System.Windows.Forms.Panel pnlRegion;
        private System.Windows.Forms.HScrollBar hScroll;
        private System.Windows.Forms.VScrollBar vScroll;
        private System.Windows.Forms.PictureBox picRegion;
        private System.Windows.Forms.ToolStripButton tsbEnableVelo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton tsbSelect;
        private System.Windows.Forms.ToolStripButton tsbWrite;
    }
}

