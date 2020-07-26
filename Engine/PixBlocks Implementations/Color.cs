using System;

namespace Engine
{
    public class Color
    {
		// Token: 0x06000ADC RID: 2780 RVA: 0x0003D4A8 File Offset: 0x0003B6A8
		public Color(int r, int g, int b)
		{
            this.r = Math.Max(0, Math.Min(r, 255));
			_g = Math.Max(0, Math.Min(g, 255));
            this.b = Math.Max(0, Math.Min(b, 255));
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0003D500 File Offset: 0x0003B700
		public Color(Color color)
		{
			r = color.r;
			_g = color.g;
			b = color.b;
		}

        // Token: 0x1700011C RID: 284
        // (get) Token: 0x06000ADE RID: 2782 RVA: 0x0003D52C File Offset: 0x0003B72C
        public int r { get; }

        // Token: 0x1700011D RID: 285
        // (get) Token: 0x06000ADF RID: 2783 RVA: 0x0003D534 File Offset: 0x0003B734
        public int g
		{
			get
			{
				return _g;
			}
		}

        // Token: 0x1700011E RID: 286
        // (get) Token: 0x06000AE0 RID: 2784 RVA: 0x0003D53C File Offset: 0x0003B73C
        public int b { get; }

        // Token: 0x040007F2 RID: 2034
        private int _g;
    }
}