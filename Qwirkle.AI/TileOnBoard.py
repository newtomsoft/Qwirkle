from Tile import Tile
from Tile import Tile
from Shape import Shape
from Color import Color
from Coordinates import Coordinates
class TileOnBoard(Tile):
    def __init__(self, tile):
        self.Shape = Shape(tile.shape)
        self.Color = Color(tile.color)
        self.Coordinates = Coordinates(tile.coordinates.x, tile.coordinates.y)