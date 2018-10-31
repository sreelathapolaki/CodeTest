# the compiler: g++ for C++
CC = g++

# compiler flags:
#  -g    adds debugging information to the executable file
#  -Wall turns on most, but not all, compiler warnings
CFLAGS  = -g -Wall

MINGW=C:\Users\sreel\Downloads\MinGW\bin
export Path:=$(MINGW);$(Path)


# the build target executable:
TARGET=dataanalyze
BOOST_DIR="C:\Program Files\boost\boost_1_68_0"

all: $(TARGET)

 $(TARGET): $(TARGET).cpp
	$(CC) $(CFLAGS) -I $(BOOST_DIR) -o $(TARGET) $(TARGET).cpp -lshlwapi
	
clean:
	$(RM) $(TARGET)