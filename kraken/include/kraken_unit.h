// kraken_unit.h
// 定义Kraken基本量结构
// 1. 数学结构
// 2. 参考系以及物理量

#pragma once

#include <Eigen/Dense>

namespace kraken
{
	//==== 基本数学数据结构 ====

	// 标量
	typedef double scalar; // 标量（双精度）

	// Eigen向量
	typedef Eigen::Vector3d vec3;	// 三维向量（双精度）
	typedef Eigen::Vector4d vec4;	// 四维向量（双精度）
	typedef vec3 eular_angle;		// 欧拉角，由三维向量表示

	// Eigen矩阵
	typedef Eigen::Matrix3d mat3;	// 3x3矩阵（双精度）
	typedef Eigen::Matrix4d mat4;	// 4x4矩阵（双精度）

	// Eigen四元数
	typedef Eigen::Quaterniond quaternion;	// 四元数（双精度）

	//==== 基本物理量 ====

	// 简单参考系
	// 相对于“绝对参考系”：需要在注释中说明“绝对坐标系”的含义。
	class reference_frame
	{
	public:
		vec3 position, velocity, ang_velocity; // 位置，速度，角速度，均相对于绝对参考系
		quaternion rotation; // 四元数旋转表示，相对于绝对参考系

	public:

		// 由给定母参考系和相对速度创建参考系
		reference_frame(const reference_frame& parent, vec3 position, vec3 velocity, vec3 ang_velocity, quaternion rotation);

		// 直接相对于绝对参考系创建参考系
		reference_frame(vec3 position, vec3 velocity, vec3 ang_velocity, quaternion rotation);

		// 将目前参考系由原绝对参考系转换为新绝对参考系
		// prev_ref：原参考系相对新参考系
		reference_frame to_ref_frame(const reference_frame& prev_ref);

		// 获取同一绝对参考系的两参考系rel,abs中rel相对于abs的相对参考系
		// 举例：LKO中两艘正在对接中的飞船rel,abs，传入rel和abs相对于绝对参考系，获取rel相对abs的参考系
		static reference_frame relative(const reference_frame& rel, const reference_frame& abs);
		
	};

	// 相对向量，适用于速度，位置和力
	struct relative_vector
	{
	public:
		vec3 vector; // 向量，相对于“绝对参考系”存储
		reference_frame ref; // 参考系

	public:

		// vector: 相对向量
		// ref: 参考系
		relative_vector(const vec3& vector, const reference_frame& ref) : vector(vector), ref(ref) {}

		// 将速度由原参考系转换为新参考系
		// ref: 原参考系相对于新参考系
		relative_vector to_ref_frame(const reference_frame& ref);
	};

	// 相对速度；单位：m/s
	typedef relative_vector velocity;

	// 相对位置；单位：m
	typedef relative_vector position;

	// 相对力；单位：N
	typedef relative_vector force;

	// 时刻；单位：s
	// 可以为相对时刻/绝对时刻
	// 欲要转换直接计算即可
	typedef scalar time;
}