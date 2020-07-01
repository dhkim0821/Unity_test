cmake_minimum_required(VERSION 3.5)

project(Unity_C_test)

set(CMAKE_DISABLE_IN_SOURCE_BUILD ON)
set(CMAKE_DISABLE_SOURCE_CHANGES  ON)
set(CMAKE_COLOR_MAKEFILE   ON)
set(CMAKE_MODULE_PATH ${PROJECT_SOURCE_DIR}/cmake)

include_directories("/usr/local/include/")
find_package(lcm REQUIRED)

file(GLOB_RECURSE sources "src/*.cpp")                   # common library cpp files
add_executable(c_test ${sources})

target_link_libraries(c_test lcm)

