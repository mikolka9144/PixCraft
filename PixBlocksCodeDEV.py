from System.Reflection import Assembly
from System import Convert
code = Assembly.LoadFile(input[0])

manager = code.CreateInstance("Engine.Logic.StartUp",True);
manager.Init();
"game."