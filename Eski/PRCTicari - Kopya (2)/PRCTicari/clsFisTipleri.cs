using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRCTicari
{
    public static class clsFisTipleri
    {
        public enum IslemYonu
        {
            Yok = 0,
            Giris = 1,
            Cikis = 2,
            Cift = 3
        }

        public enum FisTipleri
        {
            StokZayi = 101,
            StokIkram = 102,
            StokTransfer = 103,
            StokDuzeltme = 104,
            StokDevir = 105,
            CariBorc = 201,
            CariAlacak = 202,
            CariVirman = 203,
            CariDevir = 204,
            KasaTahsil = 301,
            KasaTediye = 302,
            KasaVirman = 303,
            KasaDevir = 304,
            IrsaliyeAlis = 401,
            IrsaliyeSatis = 402,
            IrsaliyeAlisIade = 403,
            IrsaliyeSatisIade = 404,
            IrsaliyeSubelerArasiSevk = 405,
            FaturaAlis = 411,
            FaturaSatis = 412,
            FaturaAlisIade = 413,
            FaturaSatisIade = 414,
            HizliSatis = 500
        }

        public static IslemYonu fncIslemYonu(FisTipleri ftFisTipi)
        {
            IslemYonu iyReturn = 0;
            switch (ftFisTipi)
            {
                case FisTipleri.StokZayi:
                case FisTipleri.StokIkram:
                case FisTipleri.CariAlacak:
                case FisTipleri.KasaTediye:
                case FisTipleri.IrsaliyeSatis:
                case FisTipleri.IrsaliyeAlisIade:
                case FisTipleri.FaturaSatis:
                case FisTipleri.FaturaAlisIade:
                case FisTipleri.HizliSatis:
                    iyReturn = IslemYonu.Cikis;
                    break;
                case FisTipleri.CariBorc:
                case FisTipleri.KasaTahsil:
                case FisTipleri.IrsaliyeAlis:
                case FisTipleri.IrsaliyeSatisIade:
                case FisTipleri.FaturaAlis:
                case FisTipleri.FaturaSatisIade:
                    iyReturn = IslemYonu.Giris;
                    break;
                case FisTipleri.StokTransfer:
                case FisTipleri.IrsaliyeSubelerArasiSevk:
                    iyReturn = IslemYonu.Cift;
                    break;
                default:
                    break;
            }
            return iyReturn;
        }

        public static string fncIslemText(FisTipleri ftFisTipi)
        {
            string strReturn = "";
            switch (ftFisTipi)
            {
                case FisTipleri.StokZayi:
                    strReturn = "Stok Zayi İşlemi";
                    break;
                case FisTipleri.StokIkram:
                    strReturn = "Stok İkram İşlemi";
                    break;
                case FisTipleri.StokTransfer:
                    strReturn = "Stok Transfer İşlemi";
                    break;
                case FisTipleri.StokDuzeltme:
                    strReturn = "Stok Düzeltme İşlemi";
                    break;
                case FisTipleri.StokDevir:
                    strReturn = "Stok Devir İşlemi";
                    break;
                case FisTipleri.CariBorc:
                    strReturn = "Cari Borç İşlemi";
                    break;
                case FisTipleri.CariAlacak:
                    strReturn = "Cari Alacak İşlemi";
                    break;
                case FisTipleri.CariVirman:
                    strReturn = "Cari Virman İşlemi";
                    break;
                case FisTipleri.CariDevir:
                    strReturn = "Cari Devir İşlemi";
                    break;
                case FisTipleri.KasaTahsil:
                    strReturn = "Kasa Tahsil İşlemi";
                    break;
                case FisTipleri.KasaTediye:
                    strReturn = "Kasa Tediye İşlemi";
                    break;
                case FisTipleri.KasaVirman:
                    strReturn = "Kasa Virman İşlemi";
                    break;
                case FisTipleri.KasaDevir:
                    strReturn = "Kasa Devir İşlemi";
                    break;
                case FisTipleri.IrsaliyeAlis:
                    strReturn = "Alış İrsaliyesi";
                    break;
                case FisTipleri.IrsaliyeSatis:
                    strReturn = "Satış İrsaliyesi";
                    break;
                case FisTipleri.IrsaliyeAlisIade:
                    strReturn = "Alış İade İrsaliyesi";
                    break;
                case FisTipleri.IrsaliyeSatisIade:
                    strReturn = "Satış İade İrsaliyesi";
                    break;
                case FisTipleri.IrsaliyeSubelerArasiSevk:
                    strReturn = "Şubeler Arası Sevk İrsaliyesi";
                    break;
                case FisTipleri.FaturaAlis:
                    strReturn = "Alış Faturası";
                    break;
                case FisTipleri.FaturaSatis:
                    strReturn = "Satış Faturası";
                    break;
                case FisTipleri.FaturaAlisIade:
                    strReturn = "Alış İade Faturası";
                    break;
                case FisTipleri.FaturaSatisIade:
                    strReturn = "Satış İade Faturası";
                    break;
                case FisTipleri.HizliSatis:
                    strReturn = "Hızlı Satış İşlemi";
                    break;
                default:
                    break;
            }
            return strReturn;
        }

        public static string fncFisTipiSQL(string strFisTipiField)
        {
            string strReturn = "CAST((CASE " + strFisTipiField + " " +
                               "WHEN " + ((int)FisTipleri.StokZayi).TOSTRING() + " THEN 'Stok Zayi' " +
                               "WHEN " + ((int)FisTipleri.StokIkram).TOSTRING() + " THEN 'Stok İkram' " +
                               "WHEN " + ((int)FisTipleri.StokTransfer).TOSTRING() + " THEN 'Stok Transfer' " +
                               "WHEN " + ((int)FisTipleri.StokDuzeltme).TOSTRING() + " THEN 'Stok Düzeltme' " +
                               "WHEN " + ((int)FisTipleri.StokDevir).TOSTRING() + " THEN 'Stok Devir' " +
                               "WHEN " + ((int)FisTipleri.CariBorc).TOSTRING() + " THEN 'Cari Borç' " +
                               "WHEN " + ((int)FisTipleri.CariAlacak).TOSTRING() + " THEN 'Cari Alacak' " +
                               "WHEN " + ((int)FisTipleri.CariVirman).TOSTRING() + " THEN 'Cari Virman' " +
                               "WHEN " + ((int)FisTipleri.CariDevir).TOSTRING() + " THEN 'Cari Devir' " +
                               "WHEN " + ((int)FisTipleri.KasaTahsil).TOSTRING() + " THEN 'Kasa Tahsil' " +
                               "WHEN " + ((int)FisTipleri.KasaTediye).TOSTRING() + " THEN 'Kasa Tediye' " +
                               "WHEN " + ((int)FisTipleri.KasaVirman).TOSTRING() + " THEN 'Kasa Virman' " +
                               "WHEN " + ((int)FisTipleri.KasaDevir).TOSTRING() + " THEN 'Kasa Devir' " +
                               "WHEN " + ((int)FisTipleri.IrsaliyeAlis).TOSTRING() + " THEN 'Alış İrsaliyesi' " +
                               "WHEN " + ((int)FisTipleri.IrsaliyeSatis).TOSTRING() + " THEN 'Satış İrsaliyesi' " +
                               "WHEN " + ((int)FisTipleri.IrsaliyeAlisIade).TOSTRING() + " THEN 'Alış İade İrsaliyesi' " +
                               "WHEN " + ((int)FisTipleri.IrsaliyeSatisIade).TOSTRING() + " THEN 'Satış İade İrsaliyesi' " +
                               "WHEN " + ((int)FisTipleri.IrsaliyeSubelerArasiSevk).TOSTRING() + " THEN 'Şubeler Arası Sevk İrsaliyesi' " +
                               "WHEN " + ((int)FisTipleri.FaturaAlis).TOSTRING() + " THEN 'Alış Faturası' " +
                               "WHEN " + ((int)FisTipleri.FaturaSatis).TOSTRING() + " THEN 'Satış Faturası' " +
                               "WHEN " + ((int)FisTipleri.FaturaAlisIade).TOSTRING() + " THEN 'Alış İade Faturası' " +
                               "WHEN " + ((int)FisTipleri.FaturaSatisIade).TOSTRING() + " THEN 'Satış İade Faturası' " +
                               "WHEN " + ((int)FisTipleri.HizliSatis).TOSTRING() + " THEN 'Hızlı Satış' " +
                               "ELSE '' END) AS VARCHAR(255))";
            return strReturn;
        }
    }
}
