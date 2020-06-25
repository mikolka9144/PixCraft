from System.Reflection import Assembly
from System import Convert
code = Assembly.Load(Convert.FromBase64String(input[0]))

manager = code.CreateInstance("Engine.Logic.StartUp",True);
delay = 0;
manager.Init(delay);
"game."