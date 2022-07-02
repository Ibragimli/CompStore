using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class ProductParametr : BaseEntity
    {
        public bool Kamera { get; set; }
        public bool Bluetooth { get; set; }

        public int TeyinatId { get; set; }
        public int ProcessorModelId { get; set; }
        public int ColorId { get; set; }
        public int VideokartRamId { get; set; }
        public int VideokartId { get; set; }
        public int RamDDRId { get; set; }
        public int RamMhzId { get; set; }
        public int RamGBId { get; set; }
        public int ProcessorGhzId { get; set; }
        public int ProcessorCacheId { get; set; }
        public int OperationSystemId { get; set; }
        public int ScreenFrequencyId { get; set; }
        public int GörüntüImkanıId { get; set; }
        public int ScreenDiagonalId { get; set; }
        public int DaxiliYaddaşId { get; set; }



        public DaxiliYaddaş DaxiliYaddaş { get; set; }
        public GörüntüImkanı GörüntüImkanı { get; set; }
        public ScreenDiagonal ScreenDiagonal { get; set; }
        public ScreenFrequency ScreenFrequency { get; set; }
        public ProcessorGhz ProcessorGhz { get; set; }
        public OperationSystem OperationSystem { get; set; }
        public ProcessorCache ProcessorCache { get; set; }
        public RamGB RamGB { get; set; }
        public Color Color { get; set; }
        public RamMhz RamMhz { get; set; }
        public RamDDR RamDDR { get; set; }
        public Videokart Videokart { get; set; }
        public Teyinat Teyinat { get; set; }
        public ProcessorModel ProcessorModel { get; set; }
        public VideokartRam VideokartRam { get; set; }
    }
}
