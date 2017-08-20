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
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Refresh();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region StokModulu
        private void tsbStokModulu_Click(object sender, EventArgs e)
        {
            tsbStokModulu.ShowDropDown();
        }

        private void tsmiStokTanitimi_Click(object sender, EventArgs e)
        {
            frmStokKarti frmForm = new frmStokKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiGrupKoduTanitimiStok_Click(object sender, EventArgs e)
        {
            frmStokGrupKarti frmForm = new frmStokGrupKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiOzelKoduTanitimiStok_Click(object sender, EventArgs e)
        {
            frmStokOzelKarti frmForm = new frmStokOzelKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiBirimTanitimi_Click(object sender, EventArgs e)
        {
            frmStokBirimKarti frmForm = new frmStokBirimKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiStokZayiIslemi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.StokZayi);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiStokIkramIslemi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.StokIkram);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiStokDuzeltmeIslemi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.StokDuzeltme);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiStokTransferIslemi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.StokTransfer);
            frmForm.MdiParent = this;
            frmForm.Show();
        }
        #endregion

        #region CariModulu
        private void tsbCariModulu_Click(object sender, EventArgs e)
        {
            tsbCariModulu.ShowDropDown();
        }

        private void tsmiCariTanitimi_Click(object sender, EventArgs e)
        {
            frmCariKarti frmForm = new frmCariKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiGrupKoduTanitimiCari_Click(object sender, EventArgs e)
        {
            frmCariGrupKarti frmForm = new frmCariGrupKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiOzelKoduTanitimiCari_Click(object sender, EventArgs e)
        {
            frmCariOzelKarti frmForm = new frmCariOzelKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiGorevTanitimi_Click(object sender, EventArgs e)
        {
            frmCariGorevKarti frmForm = new frmCariGorevKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiCariBorcIslemi_Click(object sender, EventArgs e)
        {
            frmCariIslem frmForm = new frmCariIslem(clsFisTipleri.FisTipleri.CariBorc);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiCariAlacakIslemi_Click(object sender, EventArgs e)
        {
            frmCariIslem frmForm = new frmCariIslem(clsFisTipleri.FisTipleri.CariAlacak);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiCariVirmanIslemi_Click(object sender, EventArgs e)
        {
            frmCariIslem frmForm = new frmCariIslem(clsFisTipleri.FisTipleri.CariVirman);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiCariDevirIslemi_Click(object sender, EventArgs e)
        {
            frmCariIslem frmForm = new frmCariIslem(clsFisTipleri.FisTipleri.CariDevir);
            frmForm.MdiParent = this;
            frmForm.Show();
        }
        #endregion

        #region KasaModulu
        private void tsbKasaModulu_Click(object sender, EventArgs e)
        {
            tsbKasaModulu.ShowDropDown();
        }

        private void tsmiKasaTanitimi_Click(object sender, EventArgs e)
        {
            frmKasaKarti frmForm = new frmKasaKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiKasaTahsilIslemi_Click(object sender, EventArgs e)
        {
            frmKasaIslem frmForm = new frmKasaIslem(clsFisTipleri.FisTipleri.KasaTahsil);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiKasaTediyeIslemi_Click(object sender, EventArgs e)
        {
            frmKasaIslem frmForm = new frmKasaIslem(clsFisTipleri.FisTipleri.KasaTediye);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiKasaVirmanIslemi_Click(object sender, EventArgs e)
        {
            frmKasaIslem frmForm = new frmKasaIslem(clsFisTipleri.FisTipleri.KasaVirman);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiKasaDevirIslemi_Click(object sender, EventArgs e)
        {
            frmKasaIslem frmForm = new frmKasaIslem(clsFisTipleri.FisTipleri.KasaDevir);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiPersonelMaasOdeme_Click(object sender, EventArgs e)
        {
            frmKasaIslem frmForm = new frmKasaIslem(clsFisTipleri.FisTipleri.PersonelMaasOdeme);
            frmForm.MdiParent = this;
            frmForm.Show();
        }
        #endregion

        #region IrsaliyeFatura
        private void tsbIrsaliyeFatura_Click(object sender, EventArgs e)
        {
            tsbIrsaliyeFatura.ShowDropDown();
        }

        private void tsmiAlisIrsaliyesi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.IrsaliyeAlis);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiSatisIrsaliyesi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.IrsaliyeSatis);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiAlisIadeIrsaliyesi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.IrsaliyeAlisIade);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiSatisIadeIrsaliyesi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.IrsaliyeSatisIade);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiSubelerArasiSevkIrsaliyesi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.IrsaliyeSubelerArasiSevk);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiAlisFaturasi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.FaturaAlis);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiSatisFaturasi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.FaturaSatis);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiAlisIadeFaturasi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.FaturaAlisIade);
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiSatisIadeFaturasi_Click(object sender, EventArgs e)
        {
            frmStokIslem frmForm = new frmStokIslem(clsFisTipleri.FisTipleri.FaturaSatisIade);
            frmForm.MdiParent = this;
            frmForm.Show();
        }
        #endregion

        #region Ayarlar
        private void tsbAyarlar_Click(object sender, EventArgs e)
        {
            tsbAyarlar.ShowDropDown();
        }

        private void tsmiIsyeriTanitimi_Click(object sender, EventArgs e)
        {
            frmIsyeriKarti frmForm = new frmIsyeriKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiDepoTanitimi_Click(object sender, EventArgs e)
        {
            frmDepoKarti frmForm = new frmDepoKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiBelgeTipiTanitimi_Click(object sender, EventArgs e)
        {
            frmBelgeTipiKarti frmForm = new frmBelgeTipiKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiKdvTanitimi_Click(object sender, EventArgs e)
        {
            frmKdvKarti frmForm = new frmKdvKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }

        private void tsmiParaBirimiTanitimi_Click(object sender, EventArgs e)
        {
            frmParaBirimiKarti frmForm = new frmParaBirimiKarti();
            frmForm.MdiParent = this;
            frmForm.Show();
        }
        #endregion
    }
}
