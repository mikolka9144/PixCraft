from System.Reflection import Assembly
from System import Convert
code = Assembly.Load(Convert.FromBase64String(input[0]))
size = 20;
class Player(Sprite):
	def __init__(self,manager,pointer):
		self.pointer = pointer;
		self.manager = manager;
		self.position = Vector(0,0);
		self.size = 10 ;
		self.speed = 0;
		self.image = 0;
		self.Grounded = False;
	def update(self):		
		if game.key('a'):
			self.flip = True
			self.manager.Move(0,5);
			for b in self.manager.Blocks:	
				if self.collide(b.Sprite):
					self.manager.Move(-180,5);
					break;
		elif game.key('d'):
			self.flip = False
			self.manager.Move(-180,5);
			for b in self.manager.Blocks:	
				if self.collide(b.Sprite):
					self.manager.Move(0,5);
					break;
		if game.key('space') and self.Grounded:
			self.Grounded = False;
			self.speed = 6;
			###
		for block in self.manager.Toppings:		
			if self.collide(block.Sprite):
				self.Grounded = True;
				self.pointer.LastFoliage = block;
				if self.speed < 0:
					self.speed = 0;
					break;
			
		self.manager.Move(-90,self.speed);
		if self.speed>-6:
			self.speed =self.speed - 1
			
			for b in self.manager.Blocks:	
				if(self.collide(b.Sprite) and self.speed>0):
					self.speed = -self.speed;
					self.manager.Move(90,1);
				if self.collide(b.Sprite) and self.collide(b.foliage.Sprite): 				 
					self.manager.Move(-90,3);		
class Pointer(Sprite):
	def __init__(self,point,manager):
		self.manager = manager;
		self.size = 0;
		self.point = point;
		self.LastFoliage = None;
	def update(self):
		if(game.key("c")):
			self.point.X = self.LastFoliage.Block.X
			self.point.Y = self.LastFoliage.Block.Y+19;
		elif(game.key("left")):
			self.point.Move(-180,20);
		elif(game.key("right")):
			self.point.Move(0,20);
		elif(game.key("up")):
			self.point.Move(90,20);
		elif(game.key("down")):
			self.point.Move(-90,20);
		elif(game.key("m")):
			for b in self.manager.Blocks:	
				if(self.point.Sprite.collide(b.Sprite)):
					self.manager.RemoveTile(b);
					break;
		elif(game.key("n")):
			for b in self.manager.Blocks:	
					if(self.point.Sprite.collide(b.Sprite)):
						return;
			manager.AddBlockTile(self.point.X,self.point.Y,1,size,True);
						
manager = code.CreateInstance("BlockEngine.Engine",True);
pointer = Pointer(manager.GetPointer(),manager)
player = Player(manager,pointer);
#manager.LoadMap(input[0])
manager.CreateGenerator(164,1000)

game.add(pointer);
game.add(player);
game.start();