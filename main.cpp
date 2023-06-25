
int main(void) {
	__declspec(dllimport) void launch(void);
	launch();
	return 0;
}