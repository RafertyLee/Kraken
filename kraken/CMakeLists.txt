set(SRC_PATH "./src")
set(INC_PATH "./include")

# add all source files
aux_source_directory(${SRC_PATH} SRC_LIST)
aux_source_directory(${INC_PATH} INC_LIST)
add_executable (Kraken ${SRC_LIST} ${INC_LIST})

# Eigen Library
find_package(Eigen3 CONFIG REQUIRED)
target_link_libraries(Kraken PRIVATE Eigen3::Eigen)

target_include_directories(Kraken PRIVATE ${INC_PATH})

# Use C++20
set_property(TARGET Kraken PROPERTY CXX_STANDARD 20)