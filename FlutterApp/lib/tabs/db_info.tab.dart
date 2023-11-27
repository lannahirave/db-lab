import 'package:flutter/material.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:tabbed_view/tabbed_view.dart';
import 'package:unidb/providers/db.provider.dart';
import 'package:unidb/providers/db_tabs.provider.dart';
import 'package:unidb/tabs/new_table.tab.dart';
import 'package:unidb/tabs/table.tab.dart';

class DbInfoTab extends HookConsumerWidget {
  const DbInfoTab._({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final dbState = ref.watch(dbProvider);
    final dbLoader = ref.read(dbLoaderProvider);
    final tabsController = ref.watch(tabsProvider);

    return Center(
      child: Card(
        child: IntrinsicWidth(
          child: Padding(
            padding: const EdgeInsets.all(16),
            child: dbState.when(
              data: (db) => Column(
              mainAxisSize: MainAxisSize.min,
              crossAxisAlignment: CrossAxisAlignment.center,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text('Database: ${db.dbName}'),
                const SizedBox(height: 4),
                const Divider(),
                const SizedBox(height: 4),
                ...db.tables.map(
                  (table) => Row(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      TextButton(
                        onPressed: () {
                          tabsController
                              .addTab(TableTab.create(tableName: table));
                          tabsController.selectedIndex =
                              tabsController.length - 1;
                        },
                        child: Text(table),
                      ),
                      IconButton(
                        onPressed: () async {
                          while (true) {
                            final index = tabsController.tabs.indexWhere(
                                (element) =>
                                    element.content is TableTab &&
                                    element.text == table);
                            if (index == -1) {
                              break;
                            }
                            tabsController.removeTab(index);
                          }
                          await Future.delayed(const Duration(milliseconds: 1));
                          ref.read(dbProvider.notifier).removeTable(table);
                        },
                        icon: const Icon(Icons.delete),
                      )
                    ],
                  ),
                ),
                TextButton(
                    onPressed: () {
                      tabsController.addTab(AddTableTab.create());
                      tabsController.selectedIndex = tabsController.length - 1;
                    },
                    child: const Text('add table')),
                const SizedBox(height: 4),
                const Divider(),
                const SizedBox(height: 4),
                TextButton(
                    onPressed: dbLoader.closeDb, child: const Text('close db'))
              ],
            ),
              error: (_, __) => const Text('Error'),
              loading: () => const CircularProgressIndicator(),
            ),
          ),
        ),
      ),
    );
  }

  static TabData create() {
    return TabData(
      text: 'db',
      closable: false,
      draggable: false,
      content: const DbInfoTab._(),
    );
  }
}
