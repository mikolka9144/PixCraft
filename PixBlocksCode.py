from System.Reflection import Assembly
from System import Convert
code = Assembly.Load(Convert.FromBase64String(input[0]))

manager = code.CreateInstance("Engine.Logic.StartUp",True);
manager.Init(164,1000);
manager.Lock();