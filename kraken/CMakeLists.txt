set(SRC_PATH "./src")
set(INC_PATH "./include")

# add all source files
aux_source_directory(${SRC_PATH} SRC_LIST)
add_executable (Kraken ${SRC_LIST})

target_include_directories(Kraken PRIVATE ${INC_PATH})

# Use C++20
set_property(TARGET Kraken PROPERTY CXX_STANDARD 20)