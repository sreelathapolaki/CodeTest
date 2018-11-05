# the compiler: g++ for C++
CC = g++

# compiler flags:
#  -g    adds debugging information to the executable file
#  -Wall turns on most, but not all, compiler warnings

BOOST_DIR="C:\Program Files\boost\boost_1_68_0"
CFLAGS  = -g -Wall -I./include -I $(BOOST_DIR)

SRC_DIR = src
OBJ_DIR = obj
TARGET = CSVDataParser
INC_DIR=include

MINGW=C:\Users\sreel\Downloads\MinGW\bin
export Path:=$(MINGW);$(Path)

SRC = $(wildcard $(SRC_DIR)/*.cpp)
INC = $(wildcard $(INC_DIR)/*.h)

OBJ = $(SRC:$(SRC_DIR)/%.cpp=$(OBJ_DIR)/%.o)

all: $(TARGET)

 $(TARGET): $(SRC) $(INC)
	$(CC) $(CFLAGS)  -o $(TARGET) $(SRC)  -lshlwapi

clean:
	$(RM) $(TARGET)