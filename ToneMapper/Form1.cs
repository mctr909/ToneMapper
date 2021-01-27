using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ToneMapper {
    public partial class Form1 : Form {
        private static readonly int[] ToneWidth = new int[] { 8, 10, 12, 15, 20 };
        private static readonly int[] VeloHeight = new int[] { 4, 6, 8, 10, 12, 15, 20 };
        private static int mToneWidthIdx = 0;
        private static int mVeloHeightIdx = 0;
        private static int mToneWidth = ToneWidth[mToneWidthIdx];
        private static int mVeloHeight = VeloHeight[mVeloHeightIdx];

        private static readonly Brush CursorColor = new Pen(Color.FromArgb(127, 127, 211, 127), 1.0f).Brush;
        private static readonly Pen Gray12 = new Pen(Color.FromArgb(48, 0, 0, 0), 1.0f);
        private static readonly Pen SelectAreaColor = new Pen(Color.Blue, 1.0f);

        private Font mFont = new Font("MS Gothic", 9.0f);
        private Bitmap bmpRoll;
        private Graphics gRoll;
        private Point mCursor;
        private int mDispVelos;
        private int mToneBegin;
        private int mToneEnd;
        private int mVeloBegin;
        private int mVeloEnd;
        private bool mIsDrag;
        private bool mEnableVelo = true;

        public Form1() {
            bmpRoll = new Bitmap(1, 1);
            gRoll = Graphics.FromImage(bmpRoll);
            InitializeComponent();
            tscLayer.SelectedIndex = 0;
            tsbWrite.Checked = true;
            vScroll.Value = vScroll.Minimum < 92 ? 92 : vScroll.Minimum;

            setSize();

            timer1.Interval = 16;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            setSize();
        }

        private void tscLayer_SelectedIndexChanged(object sender, EventArgs e) {
            draw();
        }

        private void tsbSelect_Click(object sender, EventArgs e) {
            tsbWrite.Image = Properties.Resources.write_disable;
            tsbSelect.Image = Properties.Resources.select;
            tsbWrite.Checked = false;
            tsbSelect.Checked = true;
        }

        private void tsbWrite_Click(object sender, EventArgs e) {
            tsbWrite.Image = Properties.Resources.write;
            tsbSelect.Image = Properties.Resources.select_disable;
            tsbWrite.Checked = true;
            tsbSelect.Checked = false;
        }

        private void tsbEnableVelo_Click(object sender, EventArgs e) {
            mEnableVelo = !mEnableVelo;
            if (mEnableVelo) {
                mVeloHeight = VeloHeight[mVeloHeightIdx];
                tsbEnableVelo.ToolTipText = "強弱入力(ON)";
                tsbEnableVelo.Image = Properties.Resources.input_velo;
            } else {
                mVeloHeight = 2;
                tsbEnableVelo.ToolTipText = "強弱入力(OFF)";
                tsbEnableVelo.Image = Properties.Resources.input_velo_disable;
            }
            setDispVelos(0);
        }

        private void tsbToneZoom_Click(object sender, EventArgs e) {
            if (mToneWidthIdx < ToneWidth.Length - 1) {
                mToneWidthIdx++;
                mToneWidth = ToneWidth[mToneWidthIdx];
            }
            if (mToneWidthIdx == ToneWidth.Length - 1) {
                tsbToneZoom.Enabled = false;
            }
            tsbToneZoomout.Enabled = true;
            setFontSize();
            draw();
        }

        private void tsbToneZoomout_Click(object sender, EventArgs e) {
            if (0 < mToneWidthIdx) {
                mToneWidthIdx--;
                mToneWidth = ToneWidth[mToneWidthIdx];
            }
            if (0 == mToneWidthIdx) {
                tsbToneZoomout.Enabled = false;
            }
            tsbToneZoom.Enabled = true;
            setFontSize();
            draw();
        }

        private void tsbVeloZoom_Click(object sender, EventArgs e) {
            setDispVelos(1);
            draw();
        }

        private void tsbVeloZoomout_Click(object sender, EventArgs e) {
            setDispVelos(-1);
            draw();
        }

        private void picRegion_MouseDown(object sender, MouseEventArgs e) {
            mIsDrag = true;
            mToneBegin = hScroll.Value + mCursor.X / mToneWidth;
            var ofsY = bmpRoll.Height % mVeloHeight;
            if (mEnableVelo) {
                mVeloBegin = 127 + vScroll.Minimum - vScroll.Value - (mCursor.Y - ofsY) / mVeloHeight;
            } else {
                mVeloBegin = 0;
            }
        }

        private void picRegion_MouseUp(object sender, MouseEventArgs e) {
            mIsDrag = false;
        }

        private void picRegion_MouseMove(object sender, MouseEventArgs e) {
            snapCursor(picRegion.PointToClient(Cursor.Position));
            mToneEnd = hScroll.Value + mCursor.X / mToneWidth;
            var ofsY = bmpRoll.Height % mVeloHeight;
            if (mEnableVelo) {
                mVeloEnd = 127 + vScroll.Minimum - vScroll.Value - (mCursor.Y - ofsY) / mVeloHeight;
            } else {
                mVeloEnd = 127;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            draw();
        }

        private void snapCursor(Point pos) {
            mCursor.X = pos.X / mToneWidth * mToneWidth;
            var tone = hScroll.Value + mCursor.X / mToneWidth;
            if (127 < tone) {
                var toneM = 127 - hScroll.Value;
                mCursor.X = toneM * mToneWidth;
            }
            if (tone < 0) {
                mCursor.X = 0;
            }

            if (picRegion.Width <= pos.X) {
                pos.X = picRegion.Width - 1;
                if (mIsDrag && hScroll.Value + hScroll.SmallChange < hScroll.Maximum) {
                    hScroll.Value += hScroll.SmallChange;
                }
            }
            if (pos.X < 0) {
                pos.X = 0;
                if (mIsDrag && 0 <= hScroll.Value - hScroll.SmallChange) {
                    hScroll.Value -= hScroll.SmallChange;
                }
            }

            var ofsY = bmpRoll.Height % mVeloHeight;
            var height = mDispVelos * mVeloHeight + ofsY;
            mCursor.Y = (pos.Y - ofsY) / mVeloHeight * mVeloHeight + ofsY;
            if (height < mCursor.Y) {
                mCursor.Y = height;
            }

            if (picRegion.Height <= pos.Y) {
                pos.Y = picRegion.Height - 1;
                if (mIsDrag && vScroll.Value < vScroll.Maximum) {
                    vScroll.Value++;
                }
            }
            if (pos.Y < 0) {
                pos.Y = 0;
                if (mIsDrag && vScroll.Minimum <= vScroll.Value - 1) {
                    vScroll.Value--;
                }
            }
        }

        private void setDispVelos(int heightIncDec) {
            if (0 < heightIncDec && mVeloHeightIdx < VeloHeight.Length - 1) {
                mVeloHeightIdx++;
                mVeloHeight = VeloHeight[mVeloHeightIdx];
            }
            if (heightIncDec < 0 && 0 < mVeloHeightIdx) {
                mVeloHeightIdx--;
                mVeloHeight = VeloHeight[mVeloHeightIdx];
            }

            if (mVeloHeightIdx == VeloHeight.Length - 1) {
                tsbVeloZoom.Enabled = false;
            } else {
                tsbVeloZoom.Enabled = mEnableVelo;
            }
            if (0 == mVeloHeightIdx) {
                tsbVeloZoomout.Enabled = false;
            } else {
                tsbVeloZoomout.Enabled = mEnableVelo;
            }

            mDispVelos = picRegion.Height / mVeloHeight;
            if (128 < mDispVelos) {
                mDispVelos = 128;
            }
            vScroll.Maximum = 128;
            vScroll.Minimum = mDispVelos;
            vScroll.SmallChange = 1;
            vScroll.LargeChange = 1;
        }

        private void setSize() {
            if (Height < toolStrip1.Height + hScroll.Height + 40) {
                Height = toolStrip1.Height + hScroll.Height + 40;
            }

            pnlRegion.Left = 5;
            pnlRegion.Top = toolStrip1.Bottom;
            pnlRegion.Width = Width - 21;
            pnlRegion.Height = Height - toolStrip1.Height - 39;

            picRegion.Left = 0;
            picRegion.Top = 0;
            picRegion.Width = pnlRegion.Width - vScroll.Width;
            picRegion.Height = pnlRegion.Height - hScroll.Height;

            hScroll.Left = 0;
            hScroll.Top = picRegion.Bottom;
            hScroll.Width = picRegion.Width;

            vScroll.Left = picRegion.Right;
            vScroll.Top = 0;
            vScroll.Height = picRegion.Height;

            gRoll.Dispose();
            bmpRoll = new Bitmap(picRegion.Width, picRegion.Height);
            gRoll = Graphics.FromImage(bmpRoll);

            setDispVelos(0);
        }

        private void setFontSize() {
            int fsize = 7;
            while (true) {
                var newFont = new Font(mFont.Name, fsize);
                if (16 < fsize || mToneWidth + 2 < gRoll.MeasureString("4", newFont).Width) {
                    break;
                }
                mFont = newFont;
                fsize++;
            }
        }

        private void draw() {
            var dispTones = picRegion.Width / mToneWidth;
            var dispVelos = picRegion.Height / mVeloHeight;
            var ofsY = bmpRoll.Height % mVeloHeight;
            var height = mDispVelos * mVeloHeight + ofsY;

            gRoll.Clear(Color.Transparent);

            for (int i = 0, no = hScroll.Value; i < dispTones && no < 128; i++, no++) {
                switch (no % 12) {
                case 1:
                case 3:
                case 6:
                case 8:
                case 10:
                    gRoll.FillRectangle(Brushes.LightGray, i * mToneWidth, 0, mToneWidth, height);
                    gRoll.DrawLine(Pens.Gray, i * mToneWidth, 0, i * mToneWidth, height);
                    break;
                default:
                    gRoll.DrawLine(Pens.Gray, i * mToneWidth, 0, i * mToneWidth, height);
                    break;
                }
            }

            if (mEnableVelo) {
                for (int y = mDispVelos - 1, no = 128 - vScroll.Value; 0 <= y; y--, no++) {
                    var py = mVeloHeight * y + ofsY;
                    if (no % 16 == 0) {
                        var name = no.ToString();
                        var fsize = gRoll.MeasureString(name, mFont).Height - 2;
                        gRoll.DrawLine(Pens.Gray, 0, py + mVeloHeight, bmpRoll.Width, py + mVeloHeight);
                    } else {
                        gRoll.DrawLine(Gray12, 0, py + mVeloHeight, bmpRoll.Width, py + mVeloHeight);
                    }
                }
            }

            if (mIsDrag) {
                int x1 = (mToneBegin - hScroll.Value) * mToneWidth;
                int x2 = (mToneEnd - hScroll.Value) * mToneWidth;
                if (x2 < x1) {
                    var tmp = x2;
                    x2 = x1 + mToneWidth;
                    x1 = tmp;
                } else {
                    x2 += mToneWidth;
                }

                int y1 = (127 - mVeloBegin - vScroll.Value + vScroll.Minimum) * mVeloHeight + ofsY;
                int y2 = (127 - mVeloEnd - vScroll.Value + vScroll.Minimum) * mVeloHeight + ofsY;
                if (y2 < y1) {
                    var tmp = y2;
                    y2 = y1 + mVeloHeight;
                    y1 = tmp;
                } else {
                    y2 += mVeloHeight;
                }

                if (height < y2) {
                    y2 = height;
                }

                if (tsbSelect.Checked) {
                    gRoll.DrawRectangle(SelectAreaColor, x1, y1, x2 - x1, y2 - y1);
                }
                if (tsbWrite.Checked) {
                    gRoll.FillRectangle(CursorColor, x1, y1, x2 - x1, y2 - y1);
                    gRoll.DrawRectangle(Pens.Blue, x1, y1, x2 - x1, y2 - y1);
                }
            } else {
                gRoll.FillRectangle(CursorColor, mCursor.X + 1, 0, mToneWidth - 1, height);
                gRoll.DrawLine(Pens.Red, 0, mCursor.Y + mVeloHeight / 2, bmpRoll.Width, mCursor.Y + mVeloHeight / 2);
            }

            for (int i = 0, no = hScroll.Value; i < dispTones && no < 128; i++, no++) {
                if (0 == no % 12) {
                    gRoll.DrawString((no / 12 - 1).ToString(), mFont, Brushes.Black, i * mToneWidth, 0);
                }
            }

            if (mEnableVelo) {
                for (int y = mDispVelos - 1, no = 128 - vScroll.Value; 0 <= y; y--, no++) {
                    if (no % 16 == 0) {
                        var py = mVeloHeight * y + ofsY;
                        var name = no.ToString();
                        var fsize = gRoll.MeasureString(name, mFont).Height - 4;
                        gRoll.DrawString(name, mFont, Brushes.Black, 0, py + mVeloHeight - fsize);
                    }
                }
            }

            picRegion.Image = bmpRoll;
        }
    }
}
