using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.Experimental.GraphView;
#endif
using UnityEngine;
using UnityEngine.UIElements;
using VNCreator.Editors.Graph;

namespace VNCreator
{
    public class SaveUtility
    {
#if UNITY_EDITOR
        // Fungsi untuk menyimpan data grafik ke dalam objek cerita
public void SaveGraph(StoryObject _story, ExtendedGraphView _graph)
{
    // Menandakan bahwa objek cerita telah berubah
    EditorUtility.SetDirty(_story);

    // Membuat daftar node dan link kosong
    List<NodeData> nodes = new List<NodeData>();
    List<Link> links = new List<Link>();

    // Mengumpulkan informasi dari setiap node dalam grafik
    foreach (BaseNode _node in _graph.nodes.ToList().Cast<BaseNode>().ToList())
    {
        // Menambahkan informasi node ke dalam daftar node
        nodes.Add(
            new NodeData
            {
                // Mengisi properti node dengan data yang sesuai
                guid = _node.nodeData.guid,
                characterSpr = _node.nodeData.characterSpr,
                characterName = _node.nodeData.characterName,
                dialogueText = _node.nodeData.dialogueText,
                backgroundSpr = _node.nodeData.backgroundSpr,
                startNode = _node.nodeData.startNode,
                endNode = _node.nodeData.endNode,
                choices = _node.nodeData.choices,
                choiceOptions = _node.nodeData.choiceOptions,
                nodePosition = _node.GetPosition(),
                soundEffect = _node.nodeData.soundEffect,
                backgroundMusic = _node.nodeData.backgroundMusic
            });
    }

    // Mengumpulkan informasi link antara node-node dalam grafik
    List<Edge> _edges = _graph.edges.ToList();
    for (int i = 0; i < _edges.Count; i++)
    {
        // Mendapatkan node output dan input dari setiap link
        BaseNode _output = (BaseNode)_edges[i].output.node;
        BaseNode _input = (BaseNode)_edges[i].input.node;

        // Menambahkan informasi link ke dalam daftar link
        links.Add(new Link
        {
            guid = _output.nodeData.guid,
            targetGuid = _input.nodeData.guid,
            portId = i
        });
    }

    // Mengatur daftar node dan link dalam objek cerita
    _story.SetLists(nodes, links);
}

// Fungsi untuk memuat data grafik dari objek cerita ke dalam tampilan grafik
public void LoadGraph(StoryObject _story, ExtendedGraphView _graph)
{
    // Membuat node-node berdasarkan informasi yang ada dalam objek cerita
    foreach (NodeData _data in _story.nodes)
    {
        BaseNode _tempNode = _graph.CreateNode("", _data.nodePosition.position, _data.choices, _data.choiceOptions, _data.startNode, _data.endNode, _data);
        _graph.AddElement(_tempNode);
    }

    // Menghubungkan node-node sesuai dengan data link dalam objek cerita
    GenerateLinks(_story, _graph);
}

// Fungsi untuk menghubungkan node-node dalam tampilan grafik berdasarkan data link dalam objek cerita
void GenerateLinks(StoryObject _story, ExtendedGraphView _graph)
{
    // Mengambil daftar node dari tampilan grafik
    List<BaseNode> _nodes = _graph.nodes.ToList().Cast<BaseNode>().ToList();

    // Melakukan penghubungan node-node sesuai dengan data link
    for (int i = 0; i < _nodes.Count; i++)
    {
        int _outputIdx = 1;
        // Mencari link-link yang terkait dengan node saat ini
        List<Link> _links = _story.links.Where(x => x.guid == _nodes[i].nodeData.guid).ToList();
        for (int j = 0; j < _links.Count; j++)
        {
            // Mendapatkan node target berdasarkan guid dari link
            string targetGuid = _links[j].targetGuid;
            BaseNode _target = _nodes.First(x => x.nodeData.guid == targetGuid);
            // Menghubungkan node-node dengan memanipulasi port-port
            LinkNodes(_nodes[i].outputContainer[_links.Count > 1 ? _outputIdx : 0].Q<Port>(), (Port)_target.inputContainer[0], _graph);
            _outputIdx += 2;
        }
    }
}

// Fungsi untuk menghubungkan dua node melalui port
void LinkNodes(Port _output, Port _input, ExtendedGraphView _graph)
{
    // Membuat edge baru untuk menghubungkan port output dan input
    Edge _temp = new Edge
    {
        output = _output,
        input = _input
    };

    // Menghubungkan edge dengan port dan menambahkannya ke tampilan grafik
    _temp.input.Connect(_temp);
    _temp.output.Connect(_temp);
    _graph.Add(_temp);
}
#endif
    }
}
