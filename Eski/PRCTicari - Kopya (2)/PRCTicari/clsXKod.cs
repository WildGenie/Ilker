using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRCTicari
{
    public static class clsXKod
    {
        private static object prcdXKodCagir(string strFormText, string strSQL, string[] arrParamNames, object[] arrParamValues, string[] arrFields, string[] arrFieldTitles, int[] arrFieldWidths, int intDefaultCriterIndex, int intReturnFieldIndex)
        {
            object oXKodSelected = null;
            frmXKod frmForm = new frmXKod(strFormText, strSQL, arrParamNames, arrParamValues, arrFields, arrFieldTitles, arrFieldWidths, intDefaultCriterIndex, intReturnFieldIndex);
            if (frmForm.ShowDialog() == DialogResult.OK) oXKodSelected = frmForm.oXKodSelected;
            frmForm.Dispose();
            return oXKodSelected;
        }

        public static object fncSECStok()
        {
            return prcdXKodCagir("Stok Seçme Listesi",
                                 "SELECT Stok_Kodu, Stok_Adi FROM Stok_Tanitimi WHERE Silindi = 0",
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Stok_Kodu", "Stok_Adi" },
                                 new string[] { "Stok Kodu", "Stok Adı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECStokGrupKodu()
        {
            return prcdXKodCagir("Stok Grup Kodu Seçme Listesi",
                                 "SELECT Grup_Kodu, Grup_Adi FROM Stok_Grup_Tanitimi",
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Grup_Kodu", "Grup_Adi" },
                                 new string[] { "Grup Kodu", "Grup Adı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECStokOzelKodu()
        {
            return prcdXKodCagir("Stok Özel Kodu Seçme Listesi",
                                 "SELECT Ozel_Kodu, Ozel_Adi FROM Stok_Ozel_Tanitimi",
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Ozel_Kodu", "Ozel_Adi" },
                                 new string[] { "Özel Kodu", "Özel Adı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECStokBirim(int intStokNo)
        {
            return prcdXKodCagir("Stok Birim Seçme Listesi",
                                 "SELECT ST.Birim_Kodu_1 AS Birim_Kodu, SBT.Birim_Adi FROM Stok_Tanitimi AS ST INNER JOIN Stok_Birim_Tanitimi AS SBT ON SBT.Birim_Kodu = ST.Birim_Kodu_1 WHERE ST.Silindi = 0 AND LTRIM(RTRIM(Birim_Kodu_1)) <> '' AND ST.Stok_No = @Stok_No " +
                                 "UNION " +
                                 "SELECT ST.Birim_Kodu_2 AS Birim_Kodu, SBT.Birim_Adi FROM Stok_Tanitimi AS ST INNER JOIN Stok_Birim_Tanitimi AS SBT ON SBT.Birim_Kodu = ST.Birim_Kodu_2 WHERE ST.Silindi = 0 AND LTRIM(RTRIM(Birim_Kodu_2)) <> '' AND ST.Stok_No = @Stok_No",
                                 new string[] { "@Stok_No" },
                                 new object[] { intStokNo },
                                 new string[] { "Birim_Kodu", "Birim_Adi" },
                                 new string[] { "Birim Kodu", "Birim Adı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECCari()
        {
            return prcdXKodCagir("Cari Seçme Listesi",
                                 "SELECT Cari_Kodu, Unvani FROM Cari_Tanitimi WHERE Silindi = 0",
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Cari_Kodu", "Unvani" },
                                 new string[] { "Cari Kodu", "Ünvanı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECMusteri()
        {
            return prcdXKodCagir("Cari Seçme Listesi",
                                 "SELECT Cari_Kodu, Unvani FROM Cari_Tanitimi WHERE Silindi = 0 AND Musteri = 1",
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Cari_Kodu", "Unvani" },
                                 new string[] { "Cari Kodu", "Ünvanı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECCariGrupKodu()
        {
            return prcdXKodCagir("Cari Grup Kodu Seçme Listesi",
                                 "SELECT Grup_Kodu, Grup_Adi FROM Cari_Grup_Tanitimi",
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Grup_Kodu", "Grup_Adi" },
                                 new string[] { "Grup Kodu", "Grup Adı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECCariOzelKodu()
        {
            return prcdXKodCagir("Cari Özel Kodu Seçme Listesi",
                                 "SELECT Ozel_Kodu, Ozel_Adi FROM Cari_Ozel_Tanitimi",
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Ozel_Kodu", "Ozel_Adi" },
                                 new string[] { "Özel Kodu", "Özel Adı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECCariGorevKodu()
        {
            return prcdXKodCagir("Görev Kodu Seçme Listesi",
                                 "SELECT Gorev_Kodu, Gorev_Adi FROM Cari_Gorev_Tanitimi",
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Gorev_Kodu", "Gorev_Adi" },
                                 new string[] { "Görev Kodu", "Görev Adı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECMasraf(bool blnIslemOnly = false)
        {
            return prcdXKodCagir("Masraf Kodu Seçme Listesi",
                                 "SELECT Masraf_Kodu, Masraf_Adi FROM Masraf_Tanitimi " + (blnIslemOnly ? "WHERE Islem = 1" : ""),
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Masraf_Kodu", "Masraf_Adi" },
                                 new string[] { "Masraf Kodu", "Masraf Adı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECKasa()
        {
            return prcdXKodCagir("Kasa Seçme Listesi",
                                 "SELECT Kasa_Kodu, Kasa_Adi FROM Kasa_Tanitimi WHERE Silindi = 0",
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Kasa_Kodu", "Kasa_Adi" },
                                 new string[] { "Kasa Kodu", "Kasa Adı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECKdv()
        {
            return prcdXKodCagir("Kdv Seçme Listesi",
                                 "SELECT Kdv_Orani, Kdv_Adi FROM Kdv_Tanitimi",
                                 new string[] { },
                                 new object[] { },
                                 new string[] { "Kdv_Orani", "Kdv_Adi" },
                                 new string[] { "Kdv Oranı", "Kdv Adı" },
                                 new int[] { 100, 250 },
                                 1, 0);
        }

        public static object fncSECFisStok(clsFisTipleri.FisTipleri ftFisTipi, int intIsyeriKodu)
        {
            object oReturn = null;
            if (ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlis || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlisIade ||
                ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatis || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatisIade ||
                ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlis || ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlisIade ||
                ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatis || ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatisIade)
            {
                oReturn = prcdXKodCagir(clsFisTipleri.fncIslemText(ftFisTipi) + " Seçme Listesi",
                                        "SELECT IB.Fis_No, CONVERT(VARCHAR, IB.Fis_Tarihi, 104) AS Fis_Tarihi, CT.Cari_Kodu, CT.Unvani, IB.Belge_Tipi, IB.Belge_No, CONVERT(VARCHAR, IB.Belge_Tarihi, 104) AS Belge_Tarihi, ISNULL(SUM(ABS(ID.Cikis_Tutari_Net - ID.Giris_Tutari_Net)), CAST(0 AS FLOAT)) AS Tutari, IB.Aciklama " +
                                        "FROM Islem_Baslik AS IB " +
                                        "INNER JOIN Islem_Detay_Stok AS ID ON IB.Fis_Tipi = ID.Fis_Tipi AND IB.Isyeri_Kodu = ID.Isyeri_Kodu AND IB.Fis_No = ID.Fis_No AND IB.Silindi = ID.Silindi " +
                                        "INNER JOIN Depo_Tanitimi AS DT ON DT.Depo_Kodu = IB.Depo_Kodu_1 " +
                                        "LEFT OUTER JOIN Cari_Tanitimi AS CT ON CT.Silindi = 0 AND CT.Cari_No = IB.Cari_No " +
                                        "WHERE IB.Silindi = 0 AND IB.Fis_Tipi = @Fis_Tipi AND IB.Isyeri_Kodu = @Isyeri_Kodu " +
                                        "GROUP BY IB.Fis_No, IB.Fis_Tarihi, CT.Cari_Kodu, CT.Unvani, IB.Belge_Tipi, IB.Belge_No, IB.Belge_Tarihi, IB.Aciklama",
                                        new string[] { "@Fis_Tipi", "@Isyeri_Kodu" },
                                        new object[] { ((int)ftFisTipi), intIsyeriKodu },
                                        new string[] { "Fis_No", "Fis_Tarihi", "Cari_Kodu", "Unvani", "Belge_Tipi", "Belge_No", "Belge_Tarihi", "Tutari", "Aciklama" },
                                        new string[] { "Fiş No", "Fiş Tarihi", "Cari Kodu", "Ünvanı", "Belge Tipi", "Belge No", "Belge Tarihi", "Tutarı", "Açıklama" },
                                        new int[] { 50, 75, 100, 200, 100, 100, 75, 75, 150 },
                                        3, 0);
            }
            else if (ftFisTipi == clsFisTipleri.FisTipleri.StokZayi || ftFisTipi == clsFisTipleri.FisTipleri.StokIkram)
            {
                oReturn = prcdXKodCagir(clsFisTipleri.fncIslemText(ftFisTipi) + " Seçme Listesi",
                                        "SELECT IB.Fis_No, CONVERT(VARCHAR, IB.Fis_Tarihi, 104) AS Fis_Tarihi, IB.Depo_Kodu_1 AS Depo_Kodu, DT.Depo_Adi, IB.Belge_Tipi, IB.Belge_No, CONVERT(VARCHAR, IB.Belge_Tarihi, 104) AS Belge_Tarihi, ISNULL(SUM(ABS(ID.Cikis_Tutari_Net - ID.Giris_Tutari_Net)), CAST(0 AS FLOAT)) AS Tutari, IB.Aciklama " +
                                        "FROM Islem_Baslik AS IB " +
                                        "INNER JOIN Islem_Detay_Stok AS ID ON IB.Fis_Tipi = ID.Fis_Tipi AND IB.Isyeri_Kodu = ID.Isyeri_Kodu AND IB.Fis_No = ID.Fis_No AND IB.Silindi = ID.Silindi " +
                                        "INNER JOIN Depo_Tanitimi AS DT ON DT.Depo_Kodu = IB.Depo_Kodu_1 " +
                                        "WHERE IB.Silindi = 0 AND IB.Fis_Tipi = @Fis_Tipi AND IB.Isyeri_Kodu = @Isyeri_Kodu " +
                                        "GROUP BY IB.Fis_No, IB.Fis_Tarihi, IB.Depo_Kodu_1, DT.Depo_Adi, IB.Belge_Tipi, IB.Belge_No, IB.Belge_Tarihi, IB.Aciklama",
                                        new string[] { "@Fis_Tipi", "@Isyeri_Kodu" },
                                        new object[] { ((int)ftFisTipi), intIsyeriKodu },
                                        new string[] { "Fis_No", "Fis_Tarihi", "Depo_Kodu", "Depo_Adi", "Belge_Tipi", "Belge_No", "Belge_Tarihi", "Tutari", "Aciklama" },
                                        new string[] { "Fiş No", "Fiş Tarihi", "Depo Kodu", "Depo Adı", "Belge Tipi", "Belge No", "Belge Tarihi", "Tutarı", "Açıklama" },
                                        new int[] { 50, 75, 75, 100, 100, 100, 75, 75, 150 },
                                        0, 0);
            }
            else if (ftFisTipi == clsFisTipleri.FisTipleri.StokTransfer || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSubelerArasiSevk)
            {
                oReturn = prcdXKodCagir(clsFisTipleri.fncIslemText(clsFisTipleri.FisTipleri.StokTransfer) + " Seçme Listesi",
                                        "SELECT IB.Fis_No, CONVERT(VARCHAR, IB.Fis_Tarihi, 104) AS Fis_Tarihi, IB.Depo_Kodu_1 AS V_Depo_Kodu, DT1.Depo_Adi AS V_Depo_Adi, IB.Depo_Kodu_2 AS A_Depo_Kodu, DT2.Depo_Adi AS A_Depo_Adi, ISNULL(SUM(ABS(ID.Cikis_Tutari_Net - ID.Giris_Tutari_Net)), CAST(0 AS FLOAT)) AS Tutari, IB.Aciklama " +
                                        "FROM Islem_Baslik AS IB " +
                                        "INNER JOIN Islem_Detay_Stok AS ID ON IB.Fis_Tipi = ID.Fis_Tipi AND IB.Isyeri_Kodu = ID.Isyeri_Kodu AND IB.Fis_No = ID.Fis_No AND IB.Silindi = ID.Silindi " +
                                        "INNER JOIN Depo_Tanitimi AS DT1 ON DT1.Depo_Kodu = IB.Depo_Kodu_1 " +
                                        "INNER JOIN Depo_Tanitimi AS DT2 ON DT2.Depo_Kodu = IB.Depo_Kodu_2 " +
                                        "WHERE IB.Silindi = 0 AND IB.Fis_Tipi = @Fis_Tipi AND IB.Isyeri_Kodu = @Isyeri_Kodu " +
                                        "GROUP BY IB.Fis_No, IB.Fis_Tarihi, IB.Depo_Kodu_1, DT1.Depo_Adi, IB.Depo_Kodu_2, DT2.Depo_Adi, IB.Belge_Tipi, IB.Belge_No, IB.Belge_Tarihi, IB.Aciklama",
                                        new string[] { "@Fis_Tipi", "@Isyeri_Kodu" },
                                        new object[] { ((int)clsFisTipleri.FisTipleri.StokTransfer), intIsyeriKodu },
                                        new string[] { "Fis_No", "Fis_Tarihi", "V_Depo_Kodu", "V_Depo_Adi", "A_Depo_Kodu", "A_Depo_Adi", "Tutari", "Aciklama" },
                                        new string[] { "Fiş No", "Fiş Tarihi", "V. Depo Kodu", "V. Depo Adı", "A. Depo Kodu", "A. Depo Adı", "Tutarı", "Açıklama" },
                                        new int[] { 50, 75, 75, 100, 75, 100, 75, 250 },
                                        0, 0);
            }
            else if (ftFisTipi == clsFisTipleri.FisTipleri.StokDuzeltme || ftFisTipi == clsFisTipleri.FisTipleri.StokDevir)
            {
                oReturn = prcdXKodCagir(clsFisTipleri.fncIslemText(ftFisTipi) + " Seçme Listesi",
                                        "SELECT IB.Fis_No, CONVERT(VARCHAR, IB.Fis_Tarihi, 104) AS Fis_Tarihi, IB.Depo_Kodu_1 AS Depo_Kodu, DT.Depo_Adi, IB.Belge_Tipi, IB.Belge_No, CONVERT(VARCHAR, IB.Belge_Tarihi, 104) AS Belge_Tarihi, IB.Aciklama " +
                                        "FROM Islem_Baslik AS IB " +
                                        "INNER JOIN Depo_Tanitimi AS DT ON DT.Depo_Kodu = IB.Depo_Kodu_1 " +
                                        "WHERE IB.Silindi = 0 AND IB.Fis_Tipi = @Fis_Tipi AND IB.Isyeri_Kodu = @Isyeri_Kodu",
                                        new string[] { "@Fis_Tipi", "@Isyeri_Kodu" },
                                        new object[] { ((int)ftFisTipi), intIsyeriKodu },
                                        new string[] { "Fis_No", "Fis_Tarihi", "Depo_Kodu", "Depo_Adi", "Belge_Tipi", "Belge_No", "Belge_Tarihi", "Aciklama" },
                                        new string[] { "Fiş No", "Fiş Tarihi", "Depo Kodu", "Depo Adı", "Belge Tipi", "Belge No", "Belge Tarihi", "Açıklama" },
                                        new int[] { 50, 75, 75, 100, 100, 100, 75, 225 },
                                        0, 0);
            }
            return oReturn;
        }

        public static object fncSECFisCari(clsFisTipleri.FisTipleri ftFisTipi, int intIsyeriKodu)
        {
            object oReturn = null;
            if (ftFisTipi == clsFisTipleri.FisTipleri.CariBorc || ftFisTipi == clsFisTipleri.FisTipleri.CariAlacak)
            {
                oReturn = prcdXKodCagir(clsFisTipleri.fncIslemText(ftFisTipi) + " Seçme Listesi",
                                        "SELECT IB.Fis_No, CONVERT(VARCHAR, IB.Fis_Tarihi, 104) AS Fis_Tarihi, IB.Belge_Tipi, IB.Belge_No, CONVERT(VARCHAR, IB.Belge_Tarihi, 104) AS Belge_Tarihi, ISNULL(SUM(ABS(ID.Borc_Tutari_Cari - ID.Alacak_Tutari_Cari)), CAST(0 AS FLOAT)) AS Tutari, IB.Aciklama " +
                                        "FROM Islem_Baslik AS IB " +
                                        "INNER JOIN Islem_Detay_Cari AS ID ON IB.Fis_Tipi = ID.Fis_Tipi AND IB.Isyeri_Kodu = ID.Isyeri_Kodu AND IB.Fis_No = ID.Fis_No AND IB.Silindi = ID.Silindi " +
                                        "WHERE IB.Silindi = 0 AND IB.Fis_Tipi = @Fis_Tipi AND IB.Isyeri_Kodu = @Isyeri_Kodu " +
                                        "GROUP BY IB.Fis_No, IB.Fis_Tarihi, IB.Belge_Tipi, IB.Belge_No, IB.Belge_Tarihi, IB.Aciklama",
                                        new string[] { "@Fis_Tipi", "@Isyeri_Kodu" },
                                        new object[] { ((int)ftFisTipi), intIsyeriKodu },
                                        new string[] { "Fis_No", "Fis_Tarihi", "Belge_Tipi", "Belge_No", "Belge_Tarihi", "Tutari", "Aciklama" },
                                        new string[] { "Fiş No", "Fiş Tarihi", "Belge Tipi", "Belge No", "Belge Tarihi", "Tutarı", "Açıklama" },
                                        new int[] { 50, 75, 100, 100, 75, 75, 150 },
                                        0, 0);
            }
            else if (ftFisTipi == clsFisTipleri.FisTipleri.CariVirman || ftFisTipi == clsFisTipleri.FisTipleri.CariDevir)
            {
                oReturn = prcdXKodCagir(clsFisTipleri.fncIslemText(ftFisTipi) + " Seçme Listesi",
                                        "SELECT IB.Fis_No, CONVERT(VARCHAR, IB.Fis_Tarihi, 104) AS Fis_Tarihi, IB.Belge_Tipi, IB.Belge_No, CONVERT(VARCHAR, IB.Belge_Tarihi, 104) AS Belge_Tarihi, ISNULL(SUM(ID.Borc_Tutari_Cari), CAST(0 AS FLOAT)) AS Borc_Tutari, ISNULL(SUM(ID.Alacak_Tutari_Cari), CAST(0 AS FLOAT)) AS Alacak_Tutari, IB.Aciklama " +
                                        "FROM Islem_Baslik AS IB " +
                                        "INNER JOIN Islem_Detay_Cari AS ID ON IB.Fis_Tipi = ID.Fis_Tipi AND IB.Isyeri_Kodu = ID.Isyeri_Kodu AND IB.Fis_No = ID.Fis_No AND IB.Silindi = ID.Silindi " +
                                        "WHERE IB.Silindi = 0 AND IB.Fis_Tipi = @Fis_Tipi AND IB.Isyeri_Kodu = @Isyeri_Kodu " +
                                        "GROUP BY IB.Fis_No, IB.Fis_Tarihi, IB.Belge_Tipi, IB.Belge_No, IB.Belge_Tarihi, IB.Aciklama",
                                        new string[] { "@Fis_Tipi", "@Isyeri_Kodu" },
                                        new object[] { ((int)ftFisTipi), intIsyeriKodu },
                                        new string[] { "Fis_No", "Fis_Tarihi", "Belge_Tipi", "Belge_No", "Belge_Tarihi", "Borc_Tutari", "Alacak_Tutari", "Aciklama" },
                                        new string[] { "Fiş No", "Fiş Tarihi", "Belge Tipi", "Belge No", "Belge Tarihi", "Borç Tutarı", "Alacak Tutarı", "Açıklama" },
                                        new int[] { 50, 75, 100, 100, 75, 75, 75, 150 },
                                        0, 0);
            }
            return oReturn;
        }

        public static object fncSECFisKasa(clsFisTipleri.FisTipleri ftFisTipi, int intIsyeriKodu)
        {
            object oReturn = null;
            if (ftFisTipi == clsFisTipleri.FisTipleri.KasaTahsil || ftFisTipi == clsFisTipleri.FisTipleri.KasaTediye)
            {
                oReturn = prcdXKodCagir(clsFisTipleri.fncIslemText(ftFisTipi) + " Seçme Listesi",
                                        "SELECT IB.Fis_No, CONVERT(VARCHAR, IB.Fis_Tarihi, 104) AS Fis_Tarihi, IB.Belge_Tipi, IB.Belge_No, CONVERT(VARCHAR, IB.Belge_Tarihi, 104) AS Belge_Tarihi, ISNULL(SUM(ABS(ID.Borc_Tutari_Kasa - ID.Alacak_Tutari_Kasa)), CAST(0 AS FLOAT)) AS Tutari, IB.Aciklama " +
                                        "FROM Islem_Baslik AS IB " +
                                        "INNER JOIN Islem_Detay_Kasa AS ID ON IB.Fis_Tipi = ID.Fis_Tipi AND IB.Isyeri_Kodu = ID.Isyeri_Kodu AND IB.Fis_No = ID.Fis_No AND IB.Silindi = ID.Silindi " +
                                        "WHERE IB.Silindi = 0 AND IB.Fis_Tipi = @Fis_Tipi AND IB.Isyeri_Kodu = @Isyeri_Kodu " +
                                        "GROUP BY IB.Fis_No, IB.Fis_Tarihi, IB.Belge_Tipi, IB.Belge_No, IB.Belge_Tarihi, IB.Aciklama",
                                        new string[] { "@Fis_Tipi", "@Isyeri_Kodu" },
                                        new object[] { ((int)ftFisTipi), intIsyeriKodu },
                                        new string[] { "Fis_No", "Fis_Tarihi", "Belge_Tipi", "Belge_No", "Belge_Tarihi", "Tutari", "Aciklama" },
                                        new string[] { "Fiş No", "Fiş Tarihi", "Belge Tipi", "Belge No", "Belge Tarihi", "Tutarı", "Açıklama" },
                                        new int[] { 50, 75, 100, 100, 75, 75, 150 },
                                        0, 0);
            }
            else if (ftFisTipi == clsFisTipleri.FisTipleri.KasaVirman || ftFisTipi == clsFisTipleri.FisTipleri.KasaDevir)
            {
                oReturn = prcdXKodCagir(clsFisTipleri.fncIslemText(ftFisTipi) + " Seçme Listesi",
                                        "SELECT IB.Fis_No, CONVERT(VARCHAR, IB.Fis_Tarihi, 104) AS Fis_Tarihi, IB.Belge_Tipi, IB.Belge_No, CONVERT(VARCHAR, IB.Belge_Tarihi, 104) AS Belge_Tarihi, ISNULL(SUM(ID.Borc_Tutari_Kasa), CAST(0 AS FLOAT)) AS Borc_Tutari, ISNULL(SUM(ID.Alacak_Tutari_Kasa), CAST(0 AS FLOAT)) AS Alacak_Tutari, IB.Aciklama " +
                                        "FROM Islem_Baslik AS IB " +
                                        "INNER JOIN Islem_Detay_Kasa AS ID ON IB.Fis_Tipi = ID.Fis_Tipi AND IB.Isyeri_Kodu = ID.Isyeri_Kodu AND IB.Fis_No = ID.Fis_No AND IB.Silindi = ID.Silindi " +
                                        "WHERE IB.Silindi = 0 AND IB.Fis_Tipi = @Fis_Tipi AND IB.Isyeri_Kodu = @Isyeri_Kodu " +
                                        "GROUP BY IB.Fis_No, IB.Fis_Tarihi, IB.Belge_Tipi, IB.Belge_No, IB.Belge_Tarihi, IB.Aciklama",
                                        new string[] { "@Fis_Tipi", "@Isyeri_Kodu" },
                                        new object[] { ((int)ftFisTipi), intIsyeriKodu },
                                        new string[] { "Fis_No", "Fis_Tarihi", "Belge_Tipi", "Belge_No", "Belge_Tarihi", "Borc_Tutari", "Alacak_Tutari", "Aciklama" },
                                        new string[] { "Fiş No", "Fiş Tarihi", "Belge Tipi", "Belge No", "Belge Tarihi", "Borç Tutarı", "Alacak Tutarı", "Açıklama" },
                                        new int[] { 50, 75, 100, 100, 75, 75, 75, 150 },
                                        0, 0);
            }
            return oReturn;
        }
    }
}
