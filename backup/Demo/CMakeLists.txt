cmake_minimum_required(VERSION 3.10) 
PROJECT(CMAKE_PROJECT)
set(CMAKE_BUILD_TYPE Debug)
set(CMAKE_BINARY_DIR ${PROJECT_SOURCE_DIR}/build)
add_subdirectory(${PROJECT_SOURCE_DIR}/src)