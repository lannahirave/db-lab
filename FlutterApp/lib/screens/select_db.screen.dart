import 'package:flutter/material.dart';
import 'package:flutter_hooks/flutter_hooks.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
import 'package:unidb/providers/db.provider.dart';

class SelectDbScreen extends HookConsumerWidget {
  const SelectDbScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    ref.watch(dbLoaderProvider);

    return Scaffold(
      appBar: AppBar(
        title: const Text('Select a database'),
      ),
      body: const Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          mainAxisSize: MainAxisSize.min,
          children: [
            OpenLocalDbButton(),
            Divider(),
            OpenGrpcDbButton(),
            Divider(),
            OpenWSDLDbButton(),
          ],
        ),
      ),
    );
  }
}

class OpenLocalDbButton extends HookConsumerWidget {
  const OpenLocalDbButton({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final loader = ref.watch(dbLoaderProvider);
    final dbNameController = useTextEditingController();

    return Column(
      children: [
        SizedBox(
          width: 200,
          child: ElevatedButton(
            onPressed: loader.openLocalDb,
            child: const Text('Open local DB'),
          ),
        ),
        const Padding(
          padding: EdgeInsets.symmetric(vertical: 4),
          child: Text('or'),
        ),
        Padding(
          padding: const EdgeInsets.only(bottom: 8),
          child: SizedBox(
            width: 200,
            child: TextField(
              controller: dbNameController,
              decoration: const InputDecoration(
                border: OutlineInputBorder(),
                labelText: 'Database name',
              ),
            ),
          ),
        ),
        SizedBox(
          width: 200,
          child: ElevatedButton(
            onPressed: () async {
              if (dbNameController.text.isEmpty) {
                return;
              }
              await loader.createLocalDb(name: dbNameController.text);
            },
            child: const Text('Create local DB'),
          ),
        ),
      ],
    );
  }
}

class OpenGrpcDbButton extends HookConsumerWidget {
  const OpenGrpcDbButton({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final loader = ref.watch(dbLoaderProvider);

    final hostController = useTextEditingController();
    final portController = useTextEditingController();

    return Column(
      children: [
        Padding(
          padding: const EdgeInsets.only(bottom: 8),
          child: SizedBox(
            width: 200,
            child: TextField(
              controller: hostController,
              decoration: const InputDecoration(
                border: OutlineInputBorder(),
                labelText: 'Host',
              ),
            ),
          ),
        ),
        Padding(
          padding: const EdgeInsets.only(bottom: 8),
          child: SizedBox(
            width: 200,
            child: TextField(
              controller: portController,
              decoration: const InputDecoration(
                border: OutlineInputBorder(),
                labelText: 'Port',
              ),
            ),
          ),
        ),
        SizedBox(
          width: 200,
          child: ElevatedButton(
            onPressed: () async {
              if (hostController.text.isEmpty || portController.text.isEmpty) {
                return;
              }
              final port = int.tryParse(portController.text);
              if (port == null) {
                return;
              }

              await loader.connectGRPCDb(host: hostController.text, port: port);
            },
            child: const Text('Connect to gRPC DB'),
          ),
        ),
      ],
    );
  }
}

class OpenWSDLDbButton extends HookConsumerWidget {
  const OpenWSDLDbButton({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final loader = ref.watch(dbLoaderProvider);

    final urlController = useTextEditingController();

    return Column(
      children: [
        Padding(
          padding: const EdgeInsets.only(bottom: 8),
          child: SizedBox(
            width: 200,
            child: TextField(
              controller: urlController,
              decoration: const InputDecoration(
                border: OutlineInputBorder(),
                labelText: 'URL',
              ),
            ),
          ),
        ),
        SizedBox(
          width: 200,
          child: ElevatedButton(
            onPressed: () async {
              if (urlController.text.isEmpty) {
                return;
              }

              await loader.connectWSDLDb(url: urlController.text);
            },
            child: const Text('Connect to WSDL DB'),
          ),
        ),
      ],
    );
  }
}

