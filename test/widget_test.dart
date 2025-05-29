import 'package:flutter_test/flutter_test.dart';
import 'package:zamanla/main.dart';

void main() {
  testWidgets('MyApp widget test', (WidgetTester tester) async {
    await tester.pumpWidget(const MyApp());
    expect(find.text('Merhaba'), findsOneWidget);
  });
}
