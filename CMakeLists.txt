cmake_minimum_required (VERSION 3.15)

set(INCLUDE_DIR ${CMAKE_CURRENT_SOURCE_DIR}/include 
F:/Project/krpc-cpp-0.5.2/include 
F:/Project/krpc-cpp-0.5.2/protobuf/include
F:/Libary/vcpkg/packages/protobuf_x64-windows/include
)
set(PROJECT_NAME tech_verif)


project(${PROJECT_NAME})


file(GLOB SRC ${CMAKE_CURRENT_SOURCE_DIR}/src/*.*)


include_directories(${INCLUDE_DIR})
link_directories(F:/Libary/vcpkg/packages/protobuf_x64-windows/lib F:/Project/krpc-cpp-0.5.2/Release F:/Project/Kraken/Tech_Verif/build/Release)
link_libraries(krpc libprotobuf)
add_library(${PROJECT_NAME} SHARED ${SRC} )
target_link_libraries(tech_verif)
link_libraries(tech_verif)
add_executable(verif main.cpp)