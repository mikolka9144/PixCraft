using System;

namespace Engine.Logic
{
	public class Vector2
	{

		// Token: 0x06000B12 RID: 2834 RVA: 0x0003DE08 File Offset: 0x0003C008
		public Vector2(int xx, int yy)
		{
			
			x = xx;
			y = yy;
		}
        public int x;
		public int y;

		public Vector2 Clone() => (Vector2)MemberwiseClone();
    }
}