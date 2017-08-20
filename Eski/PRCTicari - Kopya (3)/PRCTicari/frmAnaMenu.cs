using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRCTicari
{
    public partial class frmAnaMenu : Form
    {
        public frmAnaMenu()
        {
            InitializeComponent();
            clsGenel.prcdGetParameters();
        }

        private void frmAnaMenu_Shown(object sender, EventArgs e)
        {
            if (DateTime.Now.Date > new DateTime(2017, 05, 30))
            {
                MessageBox.Show(fncKoduReflectorIleKiraninAllahBinTurluBelasiniVersinHakkimiHelalEtmiyorum(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                Application.ExitThread();
            }
        }

        private string fncKoduReflectorIleKiraninAllahBinTurluBelasiniVersinHakkimiHelalEtmiyorum()
        {
            return "null";
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Refresh();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = !pnlMenu.Visible;
            this.Refresh();
        }

        private void tMenu_Tick(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() == 0)
            {
                tMenu.Enabled = false;
                pnlMenu.Visible = true;
                this.Refresh();
            }
        }

        private void tsbButton_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripSplitButton)
                ((ToolStripSplitButton)sender).ShowDropDown();
            else
            {
                string strTag = ((ToolStripButton)sender).Tag.TOSTRING();

                if (strTag == tsbKapat.Tag.TOSTRING())
                    Close();
                else if (strTag == tsbHizliSatis.Tag.TOSTRING())
                {
                    frmHizliSatisKantin frmForm = new frmHizliSatisKantin();
                    frmForm.MdiParent = this;
                    frmForm.Show();

                    pnlMenu.Visible = false;
                    this.Refresh();
                    tMenu.Enabled = true;
                }
            }
        }

        private void tsmiMenuItem_Click(object sender, EventArgs e)
        {
            string strTag = ((ToolStripMenuItem)sender).Tag.TOSTRING();

            Form frmForm = null;

            #region StokModulu
            if (strTag == tsmiStokTanitimi.Tag.TOSTRING())
                frmForm = new frmStokKarti();
            else if (strTag == tsmiGrupKoduTanitimiStok.Tag.TOSTRING())
                frmForm = new frmStokGrupKarti();
            else if (strTag == tsmiOzelKoduTanitimiStok.Tag.TOSTRING())
                frmForm = new frmStokOzelKarti();
            else if (strTag == tsmiBirimTanitimi.Tag.TOSTRING())
                frmForm = new frmStokBirimKarti();
            else if (strTag == tsmiStokZayiIslemi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.StokZayi);
            else if (strTag == tsmiStokIkramIslemi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.StokIkram);
            else if (strTag == tsmiStokTransferIslemi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.StokTransfer);
            else if (strTag == tsmiStokDuzeltmeIslemi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.StokDuzeltme);
            else if (strTag == tsmiStokListesi.Tag.TOSTRING())
                frmForm = new rpStokListesi(strTag);
            #endregion

            #region CariModulu
            else if (strTag == tsmiCariTanitimi.Tag.TOSTRING())
                frmForm = new frmCariKarti();
            else if (strTag == tsmiMusteriTanitimi.Tag.TOSTRING())
                frmForm = new frmMusteriKarti();
            else if (strTag == tsmiGrupKoduTanitimiCari.Tag.TOSTRING())
                frmForm = new frmCariGrupKarti();
            else if (strTag == tsmiOzelKoduTanitimiCari.Tag.TOSTRING())
                frmForm = new frmCariOzelKarti();
            else if (strTag == tsmiGorevTanitimi.Tag.TOSTRING())
                frmForm = new frmCariGorevKarti();
            else if (strTag == tsmiMasrafTanitimi.Tag.TOSTRING())
                frmForm = new frmMasrafKarti();
            else if (strTag == tsmiCariBorcIslemi.Tag.TOSTRING())
                frmForm = new frmCariIslem(clsFisTipleri.FisTipleri.CariBorc);
            else if (strTag == tsmiCariAlacakIslemi.Tag.TOSTRING())
                frmForm = new frmCariIslem(clsFisTipleri.FisTipleri.CariAlacak);
            else if (strTag == tsmiCariVirmanIslemi.Tag.TOSTRING())
                frmForm = new frmCariIslem(clsFisTipleri.FisTipleri.CariVirman);
            else if (strTag == tsmiCariDevirIslemi.Tag.TOSTRING())
                frmForm = new frmCariIslem(clsFisTipleri.FisTipleri.CariDevir);
            else if (strTag == tsmiCariListesi.Tag.TOSTRING())
                frmForm = new rpCariListesi(strTag);
            #endregion

            #region KasaModulu
            else if (strTag == tsmiKasaTanitimi.Tag.TOSTRING())
                frmForm = new frmKasaKarti();
            else if (strTag == tsmiKasaTahsilIslemi.Tag.TOSTRING())
                frmForm = new frmKasaIslem(clsFisTipleri.FisTipleri.KasaTahsil);
            else if (strTag == tsmiKasaTediyeIslemi.Tag.TOSTRING())
                frmForm = new frmKasaIslem(clsFisTipleri.FisTipleri.KasaTediye);
            else if (strTag == tsmiKasaVirmanIslemi.Tag.TOSTRING())
                frmForm = new frmKasaIslem(clsFisTipleri.FisTipleri.KasaVirman);
            else if (strTag == tsmiKasaDevirIslemi.Tag.TOSTRING())
                frmForm = new frmKasaIslem(clsFisTipleri.FisTipleri.KasaDevir);
            else if (strTag == tsmiKasaListesi.Tag.TOSTRING())
                frmForm = new rpKasaListesi(strTag);
            #endregion

            #region IrsaliyeFatura
            else if (strTag == tsmiAlisIrsaliyesi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.IrsaliyeAlis);
            else if (strTag == tsmiSatisIrsaliyesi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.IrsaliyeSatis);
            else if (strTag == tsmiAlisIadeIrsaliyesi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.IrsaliyeAlisIade);
            else if (strTag == tsmiSatisIadeIrsaliyesi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.IrsaliyeSatisIade);
            else if (strTag == tsmiSubelerArasiSevkIrsaliyesi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.IrsaliyeSubelerArasiSevk);
            else if (strTag == tsmiAlisFaturasi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.FaturaAlis);
            else if (strTag == tsmiSatisFaturasi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.FaturaSatis);
            else if (strTag == tsmiAlisIadeFaturasi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.FaturaAlisIade);
            else if (strTag == tsmiSatisIadeFaturasi.Tag.TOSTRING())
                frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.FaturaSatisIade);
            else if (strTag == tsmiIrsaliyeListesi.Tag.TOSTRING())
                frmForm = new rpIrsaliyeListesi(strTag);
            else if (strTag == tsmiFaturaListesi.Tag.TOSTRING())
                frmForm = new rpFaturaListesi(strTag);
            #endregion

            #region Ayarlar
            else if (strTag == tsmiIsyeriTanitimi.Tag.TOSTRING())
                frmForm = new frmIsyeriKarti();
            else if (strTag == tsmiDepoTanitimi.Tag.TOSTRING())
                frmForm = new frmDepoKarti();
            else if (strTag == tsmiBelgeTipiTanitimi.Tag.TOSTRING())
                frmForm = new frmBelgeTipiKarti();
            else if (strTag == tsmiKdvTanitimi.Tag.TOSTRING())
                frmForm = new frmKdvKarti();
            else if (strTag == tsmiParaBirimiTanitimi.Tag.TOSTRING())
                frmForm = new frmParaBirimiKarti();
            else if (strTag == tsmiOdemeTanitimi.Tag.TOSTRING())
                frmForm = new frmOdemeKarti();
            #endregion

            if (frmForm != null)
            {
                frmForm.MdiParent = this;
                frmForm.Show();
            }

            if (this.MdiChildren.Count() > 0)
            {
                pnlMenu.Visible = false;
                this.Refresh();
                tMenu.Enabled = true;
            }
        }
    }
}
