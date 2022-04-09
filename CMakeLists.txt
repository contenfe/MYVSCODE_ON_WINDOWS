PROJECT(EXECUTE)
SET(SRC_LIST main.cpp)
MESSAGE(STATUS "This is binary dir" ${BINARY_DIR})
MESSAGE(STATUS "This is source dir" ${SOURCE_DIR})
ADD_EXECUTABLE(execute SRC_LIST)


# windows平台下
#  1、删除目录下CMakeCache.txt（如果有的话）；
# 2、执行cmake . -G "Unix Makefiles"；
# 3、然后可以执行make了。