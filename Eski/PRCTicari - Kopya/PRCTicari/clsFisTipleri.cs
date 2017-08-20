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
            PersonelMaasOdeme = 305,
            IrsaliyeAlis = 401,
            IrsaliyeSatis = 402,
            IrsaliyeAlisIade = 403,
            IrsaliyeSatisIade = 404,
            IrsaliyeSubelerArasiSevk = 405,
            FaturaAlis = 411,
            FaturaSatis = 412,
            FaturaAlisIade = 413,
            FaturaSatisIade = 414
        }

        public static IslemYonu fncIslemYonu(FisTipleri ftFisTipi)
        {
            IslemYonu iyReturn = 0;
            switch (ftFisTipi)
            {
                case FisTipleri.StokZayi:
                case FisTipleri.StokIkram:
                case FisTipleri.CariBorc:
                case FisTipleri.KasaTediye:
                case FisTipleri.IrsaliyeSatis:
                case FisTipleri.IrsaliyeAlisIade:
                case FisTipleri.FaturaSatis:
                case FisTipleri.FaturaAlisIade:
                    iyReturn = IslemYonu.Cikis;
                    break;
                case FisTipleri.CariAlacak:
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
                case FisTipleri.PersonelMaasOdeme:
                    strReturn = "Personel Maaş Ödeme İşlemi";
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
                default:
                    break;
            }
            return strReturn;
        }
    }
}
