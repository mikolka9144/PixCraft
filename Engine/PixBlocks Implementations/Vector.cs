namespace Engine
{
    public class Vector
    {
		public void SetSprite(Sprite sprite)
		{
			this.sprite = sprite;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0003DE08 File Offset: 0x0003C008
		public Vector(double xx, double yy)
		{
			if (xx == double.NaN)
			{
				throw new Exception("NaN value");
			}
			if (yy == double.NaN)
			{
				throw new Exception("NaN value");
			}
			this._x = xx;
			this._y = yy;
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x0003DE57 File Offset: 0x0003C057
		public double length
		{
			get
			{
				return Math.Sqrt(this._x * this._x + this._y * this._y);
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000B14 RID: 2836 RVA: 0x0003DE79 File Offset: 0x0003C079
		public double angle
		{
			get
			{
				return 180.0 * Math.Atan2(this._y, this._x) / 3.1415926535897931;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x0003DEA0 File Offset: 0x0003C0A0
		// (set) Token: 0x06000B16 RID: 2838 RVA: 0x0003DEA8 File Offset: 0x0003C0A8
		public double x
		{
			get
			{
				return this._x;
			}
			set
			{
				this._x = value;
				if (this.sprite != null)
				{
					if (value == double.NaN)
					{
						throw new Exception("NaN value");
					}
					this._x = Math.Min(Math.Max(-100.0, value), 100.0);
					this.sprite.xPrivate = this._x;
				}
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000B17 RID: 2839 RVA: 0x0003DF0F File Offset: 0x0003C10F
		// (set) Token: 0x06000B18 RID: 2840 RVA: 0x0003DF18 File Offset: 0x0003C118
		public double y
		{
			get
			{
				return this._y;
			}
			set
			{
				this._y = value;
				if (this.sprite != null)
				{
					if (value == double.NaN)
					{
						throw new Exception("NaN value");
					}
					this._y = Math.Min(Math.Max(-100.0, value), 100.0);
					this.sprite.yPrivate = this._y;
				}
			}
		}

		// Token: 0x04000809 RID: 2057
		private Sprite sprite;

		// Token: 0x0400080A RID: 2058
		private double _x;

		// Token: 0x0400080B RID: 2059
		private double _y;
	}
}